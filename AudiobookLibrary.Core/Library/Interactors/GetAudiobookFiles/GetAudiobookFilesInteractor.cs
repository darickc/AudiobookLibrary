using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Models;
using AudiobookLibrary.Core.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles
{
    public class GetAudiobookFilesInteractor : IRequestHandler<GetAudiobookFilesRequest, List<Series>>
    {
        private readonly AudioLibraryContext _ctx;
        public GetAudiobookFilesInteractor(AudioLibraryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Series>> Handle(GetAudiobookFilesRequest request, CancellationToken token)
        {
            _ctx.Database.EnsureCreated();
            var files = await _ctx.AudiobookFiles.OrderBy(f => f.Author).ThenBy(f => f.Album).ThenBy(f => f.Disc)
                .ThenBy(f => f.Track).ToListAsync(token);

            var series = files.GroupBy(f => new {f.Author, f.Album}).OrderBy(f => f.Key.Author)
                .ThenBy(f => f.Key.Album).Select(f=> new Series
                {
                    Name = f.Key.Album,
                    Author = f.Key.Author,
                    Image = f.FirstOrDefault()?.Image,
                    Books = f.OrderBy(b=>b.Disc).ThenBy(b=>b.Track).Select(b=>new Book
                    {
                        Image = b.Image,
                        Disc = b.Disc,
                        Track = b.Track,
                        Filename = b.Filename,
                        Title = b.Title
                    }).ToList()
                }).ToList();


            return series;
        }
    }
}