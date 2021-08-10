using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Interactors;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace AudiobookLibrary.Web.Shared
{
    public partial class MainLayout
    {
        [Inject] public IMediator Mediator { get; set; }
        bool _drawerOpen;

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        public async Task RefreshLibrary()
        {
            _drawerOpen = false;
            await Task.Run(async () =>
            {
                await Mediator.Send(new RefreshLibraryRequest());
            });
        }
    }
}
