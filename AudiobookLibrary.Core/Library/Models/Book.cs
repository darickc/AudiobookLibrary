namespace AudiobookLibrary.Core.Library.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public int? Disc { get; set; }
        public int? Track { get; set; }
        public string Image { get; set; }
        public string Filename { get; set; }
    }
}