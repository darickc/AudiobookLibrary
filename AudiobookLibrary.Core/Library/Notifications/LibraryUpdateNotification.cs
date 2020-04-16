using AudiobookLibrary.Shared.Models;
using MediatR;

namespace AudiobookLibrary.Core.Library.Notifications
{
    public class LibraryUpdateNotification : LibraryUpdate,  INotification
    {

        public LibraryUpdateNotification(int count, int filesComplete): base(count, filesComplete)
        {
        }

        public LibraryUpdateNotification(bool complete) :base(complete)
        {
        }
    }
}