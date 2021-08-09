using System.Threading.Tasks;
using AudiobookLibrary.Shared.Models;

namespace AudiobookLibrary.Web.Hubs
{
    public interface ILibraryHub
    {
        Task LibraryUpdated(LibraryUpdate notification);
    }
}