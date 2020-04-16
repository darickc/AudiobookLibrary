using System.Collections.Generic;

namespace AudiobookLibrary.Shared.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int? Disc { get; set; }
        public int? ImageId { get; set; }
        public List<Part> Parts { get; set; }
    }
}