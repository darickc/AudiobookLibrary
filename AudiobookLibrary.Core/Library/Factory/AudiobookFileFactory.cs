using System;
using System.IO;
using System.Linq;
using AudiobookLibrary.Core.Confguration;
using AudiobookLibrary.Core.Library.Domain;
using TagLib;

namespace AudiobookLibrary.Core.Library.Factory
{
    public class AudiobookFileFactory
    {
        private readonly AppSettings _settings;

        public AudiobookFileFactory(AppSettings settings)
        {
            _settings = settings;
        }

        public AudiobookFile Create(string filename)
        {
            AudiobookFile audiobookFile;
            try
            {
                var tfile = TagLib.File.Create(filename);
                audiobookFile = new AudiobookFile
                {
                    Title = tfile.Tag.Title,
                    Album = tfile.Tag.Album,
                    Author = tfile.Tag.FirstPerformer,
                    Disc = (int)tfile.Tag.Disc,
                    Track = (int)tfile.Tag.Track,
                    Filename = filename.Replace(_settings.Directory, ""),
                    Image = GetImage(tfile.Tag.Pictures)
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                audiobookFile = new AudiobookFile
                {
                    Title = Path.GetFileName(filename),
                    Filename = filename.Replace(_settings.Directory, ""),
                };
            }

            return audiobookFile;
        }

        private string GetImage(IPicture[] pictures)
        {
            var picture = pictures?.FirstOrDefault();
            if (picture == null)
            {
                return null;
            }

            var data = Convert.ToBase64String(picture.Data.Data);
            return $"data:{picture.MimeType};base64,{data}";
        }
    }
}