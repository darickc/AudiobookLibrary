using System.Collections.Generic;

namespace AudiobookLibrary.Core.Library.Models
{
    public class Series
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Book> Books { get; set; }
    }
}