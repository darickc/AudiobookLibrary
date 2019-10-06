using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Notifications;

namespace AudiobookLibrary.Web.Hubs
{
    public interface ILibraryHub
    {
        Task LibraryUpdate(LibraryUpdateNotification notification);
    }
}