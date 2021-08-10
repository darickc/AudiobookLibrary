using System;
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

        public IOrderedQueryable<AudiobookFile> GetBooks(string title, string author, string series)
        {
            return AudiobookFiles.Where(s=>
                    (string.IsNullOrEmpty(author) || s.Author.ToLower().Contains(author.ToLower())) &&
                    (string.IsNullOrEmpty(series) || s.Album.ToLower().Contains(series.ToLower())) &&
                    (string.IsNullOrEmpty(title) || s.Title.ToLower().Contains(title.ToLower())))
                .OrderBy(f => f.Author).ThenBy(f => f.Album).ThenBy(f => f.Disc)
                .ThenBy(f => f.Track);
        }
    }
}