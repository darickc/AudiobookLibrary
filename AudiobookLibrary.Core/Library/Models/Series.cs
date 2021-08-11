using System.Collections.Generic;
using System.Linq;

namespace AudiobookLibrary.Core.Library.Models
{
    public class Series
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Image => Books?.FirstOrDefault()?.Image;
        public int? ImageId { get; set; }
        public List<Book> Books { get; set; }
        public List<Book> FilteredBooks { get; set; }
        public bool ShowBooks { get; set; }
    }
}