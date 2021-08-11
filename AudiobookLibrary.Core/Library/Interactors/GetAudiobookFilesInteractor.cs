using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Library.Models;
using AudiobookLibrary.Core.Persistance;
using CSharpFunctionalExtensions;
using MediatR;

namespace AudiobookLibrary.Core.Library.Interactors
{
    public class GetAudiobookFilesRequest : IRequest<Result<PagedSeries>>
    {
        public GetAudiobookFilesRequest(string title, string author, string series, int page =1, int count = 20)
        {
            Title = title;
            Author = author;
            Series = series;
            Count = count;
            Page = page;
        }

        public string Title { get; }
        public string Author { get; }
        public string Series { get; }
        public int Page { get; }
        public int Count { get; }

        public class GetAudiobookFilesInteractor : IRequestHandler<GetAudiobookFilesRequest, Result<PagedSeries>>
        {
            private readonly AudioLibraryContext _ctx;

            public GetAudiobookFilesInteractor(AudioLibraryContext ctx)
            {
                _ctx = ctx;
            }

            public async Task<Result<PagedSeries>> Handle(GetAudiobookFilesRequest request, CancellationToken token)
            {
                await _ctx.Database.EnsureCreatedAsync(token);
                return await Result.Try(()=> _ctx.GetBooks(request.Title, request.Author, request.Series, request.Page, request.Count))
                    .Map(r => GenerateBooks(r.Files, r.Count, request.Count, r.page));
            }

            private PagedSeries GenerateBooks(List<AudiobookFile> files, int totalCount, int itemsPerPage, int page)
            {
                var series = files.GroupBy(f => new { f.Author, f.Album })
                    .OrderBy(f => f.Key.Author)
                    .ThenBy(f => f.Key.Album)
                    .Select(f => new Series
                    {
                        Name = f.Key.Album,
                        Author = f.Key.Author,
                        // Image = f.FirstOrDefault(s => !string.IsNullOrEmpty(s.Image))?.Image,
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

                return new PagedSeries
                {
                    Series = series,
                    Page = page,
                    PageCount = (int) Math.Ceiling((double) totalCount / itemsPerPage)
                };
            }
        }
    }
}