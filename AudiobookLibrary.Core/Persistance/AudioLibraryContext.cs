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

        public IOrderedQueryable<AudiobookFile> GetBooks()
        {
            return AudiobookFiles.OrderBy(f => f.Author).ThenBy(f => f.Album).ThenBy(f => f.Disc)
                .ThenBy(f => f.Track);
        }
    }
}