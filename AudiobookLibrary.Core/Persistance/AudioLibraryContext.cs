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

        
    }
}