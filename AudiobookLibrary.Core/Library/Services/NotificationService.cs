using System;
using AudiobookLibrary.Shared.Models;

namespace AudiobookLibrary.Core.Library.Services
{
    public class NotificationService
    {
        public Action<LibraryUpdate> LibraryUpdated { get; set; }

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