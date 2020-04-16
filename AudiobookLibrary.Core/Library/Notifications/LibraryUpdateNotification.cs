using AudiobookLibrary.Shared.Models;
using MediatR;

namespace AudiobookLibrary.Core.Library.Notifications
{
    public class LibraryUpdateNotification : LibraryUpdate,  INotification
    {

        public LibraryUpdateNotification(int count, int filesComplete): base(count, filesComplete, ((double)filesComplete / count) * 100)
        {
        }

        public LibraryUpdateNotification(bool complete) :base(complete)
        {
        }
    }
}