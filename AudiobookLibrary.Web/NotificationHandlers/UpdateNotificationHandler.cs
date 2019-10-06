using AudiobookLibrary.Core.Library.Notifications;
using AudiobookLibrary.Web.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace AudiobookLibrary.Web.NotificationHandlers
{
    public class UpdateNotificationHandler : NotificationHandler<LibraryUpdateNotification>
    {
        private readonly IHubContext<LibraryHub, ILibraryHub> _hub;

        public UpdateNotificationHandler(IHubContext<LibraryHub, ILibraryHub> hub)
        {
            _hub = hub;
        }

        protected override async void Handle(LibraryUpdateNotification notification)
        {
            await _hub.Clients.All.LibraryUpdate(notification);
        }
    }
}