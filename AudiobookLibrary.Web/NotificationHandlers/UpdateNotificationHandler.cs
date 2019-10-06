using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Notifications;
using AudiobookLibrary.Web.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace AudiobookLibrary.Web.NotificationHandlers
{
    public class UpdateNotificationHandler : INotificationHandler<LibraryUpdateNotification>
    {
        private readonly IHubContext<LibraryHub, ILibraryHub> _hub;

        public UpdateNotificationHandler(IHubContext<LibraryHub, ILibraryHub> hub)
        {
            _hub = hub;
        }

        public async Task Handle(LibraryUpdateNotification notification, CancellationToken cancellationToken)
        {
            await _hub.Clients.All.LibraryUpdate(notification);
        }
    }
}