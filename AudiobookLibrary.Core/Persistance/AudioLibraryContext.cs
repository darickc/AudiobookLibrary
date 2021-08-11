using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudiobookLibrary.Core.Persistance
{
    public class AudioLibraryContext : DbContext
    {
        public DbSet<AudiobookFile> AudiobookFiles { get; set; }

        public AudioLibraryContext(DbContextOptions<AudioLibraryContext> options) : base(options)
        {
        }

        public async Task<(List<AudiobookFile> Files,int Count, int page)> GetBooks(string title, string author, string series, int page, int count)
        {

            try
            {

                var q = AudiobookFiles.Where(s =>
                    (string.IsNullOrEmpty(author) || s.Author.ToLower().Contains(author.ToLower())) &&
                    (string.IsNullOrEmpty(series) || s.Album.ToLower().Contains(series.ToLower())) &&
                    (string.IsNullOrEmpty(title) || s.Title.ToLower().Contains(title.ToLower())));

                var q2 = q
                    .Select(b => new {b.Author, b.Album})
                    .Distinct();

                var totalCount = await q2.CountAsync();
                if (page < 1)
                {
                    page = 1;
                }
                else if (page * count > totalCount)
                {
                    page = (int) Math.Ceiling((double) totalCount / count);
                }

                var items = await q2.OrderBy(b=>b.Author).ThenBy(b=>b.Album)
                    .Skip((page -1) * count)
                    .Take(count)
                    .ToListAsync();
                var t = items.Select(b => $"{b.Author}-{b.Album}").ToList();

                var files = await AudiobookFiles.Where(b => t.Contains(b.Author + "-" + b.Album)).ToListAsync();

                return (files, totalCount, page);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}