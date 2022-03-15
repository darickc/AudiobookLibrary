using System;

namespace AudiobookLibrary.Core.Library.Domain
{
    public class AudiobookFile
    {
        public int AudiobookFileId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public int? Disc { get; set; }
        public int? Track { get; set; }
        public string Image { get; set; }
        public string Filename { get; set; }
        public DateTime? DateUpdated { get; set; }

        public void Update(AudiobookFile file)
        {
            if (Title != file.Title)
            {
                Title = file.Title;
            }
            if (Author != file.Author)
            {
                Author = file.Author;
            }
            if (Album != file.Album)
            {
                Album = file.Album;
            }
            if (Disc != file.Disc)
            {
                Disc = file.Disc;
            }
            if (Track != file.Track)
            {
                Track = file.Track;
            }
            if (Image != file.Image)
            {
                Image = file.Image;
            }
        }
    }
}