using System.Collections.Generic;

namespace AudiobookLibrary.Shared.Models
{
    public class Series
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public bool Image { get; set; }
        public int? ImageId { get; set; }
        public List<Book> Books { get; set; }
        public List<Book> FilteredBooks { get; set; }
        public bool ShowBooks { get; set; }
    }
}