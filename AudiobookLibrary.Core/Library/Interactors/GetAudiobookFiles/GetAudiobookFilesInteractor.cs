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
                    Image = f.First().Image,
                    Books = f.GroupBy(b=>b.Disc).OrderBy(b=>b.Key).Select(b=>new Book
                    {
                        Image =!string.IsNullOrEmpty(b.First().Image),
                        Title = b.First().Title,
                        Disc = b.Key,
                        Parts = b.OrderBy(p=>p.Track).Select(p=>new Part
                        {
                            Id = p.AudiobookFileId,
                            Track = p.Track,
                            Filename = p.Filename,
                            
                        }).ToList()
                    }).ToList()
                }).ToList();


            return series;
        }
    }
}