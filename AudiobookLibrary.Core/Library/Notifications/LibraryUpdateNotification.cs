using MediatR;

namespace AudiobookLibrary.Core.Library.Notifications
{
    public class LibraryUpdateNotification : INotification
    {
        public int Count { get; }
        public int FilesComplete { get; }
        public double Percent { get; }
        public bool Complete { get; }

        public LibraryUpdateNotification(int count, int filesComplete)
        {
            Count = count;
            FilesComplete = filesComplete;
            Percent = ((double)filesComplete / count) * 100;
        }

        public LibraryUpdateNotification(bool complete)
        {
            Complete = complete;
        }
    }
}