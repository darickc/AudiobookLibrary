using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Persistance;
using AudiobookLibrary.Shared.Models;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudiobookLibrary.Core.Library.Interactors
{
    public class GetAudiobookFilesRequest : IRequest<Result<List<Series>>>
    {
        public GetAudiobookFilesRequest(string title, string author, string series)
        {
            Title = title;
            Author = author;
            Series = series;
        }

        public string Title { get; }
        public string Author { get; }
        public string Series { get; }

        public class GetAudiobookFilesInteractor : IRequestHandler<GetAudiobookFilesRequest, Result<List<Series>>>
        {
            private readonly AudioLibraryContext _ctx;

            public GetAudiobookFilesInteractor(AudioLibraryContext ctx)
            {
                _ctx = ctx;
            }

            public async Task<Result<List<Series>>> Handle(GetAudiobookFilesRequest request, CancellationToken token)
            {
                await _ctx.Database.EnsureCreatedAsync(token);
                return await Result.Try(()=> _ctx.GetBooks(request.Title, request.Author, request.Series).ToListAsync(token))
                    .Map(GenerateBooks);
            }

            private List<Series> GenerateBooks(List<AudiobookFile> files)
            {
                return files.GroupBy(f => new { f.Author, f.Album })
                    .OrderBy(f => f.Key.Author)
                    .ThenBy(f => f.Key.Album)
                    .Select(f => new Series
                    {
                        Name = f.Key.Album,
                        Author = f.Key.Author,
                        Image = f.FirstOrDefault(s => !string.IsNullOrEmpty(s.Image))?.Image,
                        Books = f.GroupBy(b => b.Disc).OrderBy(b => b.Key).Select(b => new Book
                        {
                            Image = b.FirstOrDefault(s => !string.IsNullOrEmpty(s.Image))?.Image,
                            Title = b.First().Title,
                            Disc = b.Key,
                            Parts = b.OrderBy(p => p.Track).Select(p => new Part
                            {
                                Id = p.AudiobookFileId,
                                Track = p.Track,
                                Filename = p.Filename,

                            }).ToList()
                        }).ToList()
                    }).ToList();
            }
        }
    }
}