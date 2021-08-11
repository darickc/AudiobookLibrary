namespace AudiobookLibrary.Core.Library.Models
{
    public class LibraryUpdate
    {
        public int Count { get; set; }
        public int FilesComplete { get; set; }
        public double Percent { get; set; }
        public bool Complete { get; set; }

        public LibraryUpdate()
        {
            
        }

        public LibraryUpdate(int count, int filesComplete)
        {
            Count = count;
            FilesComplete = filesComplete;
            Percent = (double) filesComplete / count * 100;
        }

        public LibraryUpdate(bool complete)
        {
            Complete = complete;
        }

    }
}