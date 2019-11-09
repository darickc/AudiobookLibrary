using System.Collections.Generic;

namespace AudiobookLibrary.Core.Library.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int? Disc { get; set; }
        public bool Image { get; set; }
        public List<Part> Parts { get; set; }
    }
}