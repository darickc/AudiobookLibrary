using System;
using AudiobookLibrary.Core.Library.Models;

namespace AudiobookLibrary.Core.Library.Services
{
    public class NotificationService
    {
        public event Action<LibraryUpdate> LibraryUpdated;

        public void Notify(int count, int filesComplete)
        {
            LibraryUpdated?.Invoke(new LibraryUpdate(count, filesComplete));
        }

        public void Notify(bool complete)
        {
            LibraryUpdated?.Invoke(new LibraryUpdate(complete));
        }
    }
}