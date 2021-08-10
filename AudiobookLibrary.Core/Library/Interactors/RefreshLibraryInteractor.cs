using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Configuration;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Library.Factory;
using AudiobookLibrary.Core.Library.Notifications;
using AudiobookLibrary.Core.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudiobookLibrary.Core.Library.Interactors
{
    public class RefreshLibraryRequest : IRequest
    {
        public class RefreshLibraryInteractor : AsyncRequestHandler<RefreshLibraryRequest>
        {
            private readonly AudioLibraryContext _ctx;
            private readonly AppSettings _settings;
            private readonly IMediator _mediator;
            private readonly AudiobookFileFactory _audiobookFileFactory;

            public RefreshLibraryInteractor(AudioLibraryContext ctx, AppSettings settings, IMediator mediator, AudiobookFileFactory audiobookFileFactory)
            {
                _ctx = ctx;
                _settings = settings;
                _mediator = mediator;
                _audiobookFileFactory = audiobookFileFactory;
            }

            protected override async Task Handle(RefreshLibraryRequest request, CancellationToken token)
            {
                _ctx.Database.EnsureCreated();
                var directory = new DirectoryInfo(_settings.Directory);
                var files = GetFilesForDirectory(directory);
                var items = await _ctx.AudiobookFiles.ToListAsync(token);

                int processed = 0;
                await _mediator.Publish(new LibraryUpdateNotification(files.Count, processed), token);

                foreach (var file in files)
                {
                    AudiobookFile audiobookFile = _audiobookFileFactory.Create(file);

                    var item = items.FirstOrDefault(f => f.Filename == audiobookFile.Filename);
                    if (item == null)
                    {
                        _ctx.AudiobookFiles.Add(audiobookFile);
                    }
                    else
                    {
                        item.Update(audiobookFile);
                        items.Remove(item);
                    }

                    processed++;
                    await _mediator.Publish(new LibraryUpdateNotification(files.Count, processed), token);
                }

                items.ForEach(f => _ctx.Remove(f));

                await _ctx.SaveChangesAsync(token);
                await _mediator.Publish(new LibraryUpdateNotification(true), token);
            }

            private List<string> GetFilesForDirectory(DirectoryInfo directory)
            {
                var files = directory.GetFiles("*.m4b").Select(f => f.FullName).ToList();
                foreach (var directoryInfo in directory.GetDirectories())
                {
                    files.AddRange(GetFilesForDirectory(directoryInfo));
                }
                return files;
            }
        }
    }
}