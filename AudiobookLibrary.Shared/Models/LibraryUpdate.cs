namespace AudiobookLibrary.Shared.Models
{
    public class LibraryUpdate
    {
        public int Count { get; }
        public int FilesComplete { get; }
        public double Percent { get; }
        public bool Complete { get; }

        public LibraryUpdate(int count, int filesComplete, double percent)
        {
            Count = count;
            FilesComplete = filesComplete;
            Percent = percent;
        }

        public LibraryUpdate(bool complete)
        {
            Complete = complete;
        }

    }
}