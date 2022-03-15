using System;
using System.IO;
using System.Linq;
using AudiobookLibrary.Core.Configuration;
using AudiobookLibrary.Core.Library.Domain;
using TagLib;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

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
            catch
            {
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
            int maxSize = 300;
            var picture = pictures?.FirstOrDefault();
            if (picture == null)
            {
                return null;
            }

            // resize image
            using var image = Image.Load(picture.Data.Data);
            if (image.Height > maxSize || image.Width > maxSize)
            {
                int width = image.Width;
                int height = image.Height;
                if (width < height)
                {
                    height = (maxSize * height) / width;
                    width = maxSize;
                }
                else
                {
                    width = (maxSize * width) / height;
                    height = maxSize;
                }

                image.Mutate(x => x
                    .Resize(width, height));
            }
            var temp = image.ToBase64String(PngFormat.Instance);
            return temp;
        }
    }
}