using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Configuration;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Library.Factory;
using AudiobookLibrary.Core.Library.Services;
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
            private readonly NotificationService _notificationService;

            public RefreshLibraryInteractor(AudioLibraryContext ctx, AppSettings settings, IMediator mediator, AudiobookFileFactory audiobookFileFactory, NotificationService notificationService)
            {
                _ctx = ctx;
                _settings = settings;
                _mediator = mediator;
                _audiobookFileFactory = audiobookFileFactory;
                _notificationService = notificationService;
            }

            protected override async Task Handle(RefreshLibraryRequest request, CancellationToken token)
            {
                _notificationService.Notify(false);
                await _ctx.Database.EnsureCreatedAsync(token);

                var directory = new DirectoryInfo(_settings.Directory);
                var files = GetFilesForDirectory(directory);
                var items = await _ctx.AudiobookFiles.ToListAsync(token);

                int processed = 0;
                _notificationService.Notify(files.Count, processed);

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
                    _notificationService.Notify(files.Count, processed);
                }

                items.ForEach(f => _ctx.Remove(f));

                await _ctx.SaveChangesAsync(token);
                _notificationService.Notify(true);
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