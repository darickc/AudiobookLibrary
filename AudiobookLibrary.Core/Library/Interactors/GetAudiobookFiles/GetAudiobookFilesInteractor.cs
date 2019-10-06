using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles
{
    public class GetAudiobookFilesInteractor : IRequestHandler<GetAudiobookFilesRequest, List<AudiobookFile>>
    {
        private readonly AudioLibraryContext _ctx;
        public GetAudiobookFilesInteractor(AudioLibraryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<AudiobookFile>> Handle(GetAudiobookFilesRequest request, CancellationToken token)
        {
            _ctx.Database.EnsureCreated();
            var files = await _ctx.AudiobookFiles.OrderBy(f => f.Author).ThenBy(f => f.Album).ThenBy(f => f.Disc)
                .ThenBy(f => f.Track).ToListAsync(token);

            return files;
        }
    }
}