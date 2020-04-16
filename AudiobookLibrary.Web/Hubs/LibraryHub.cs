using System.Collections.Generic;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles;
using AudiobookLibrary.Core.Library.Interactors.RefreshLibrary;
using AudiobookLibrary.Core.Library.Notifications;
using AudiobookLibrary.Shared.Models;
using AudiobookLibrary.Web.BackgroundTasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AudiobookLibrary.Web.Hubs
{
    public class LibraryHub : Hub<ILibraryHub>
    {
        private readonly IMediator _mediator;
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger _logger;

        public LibraryHub(IMediator mediator, IBackgroundTaskQueue backgroundTaskQueue, IServiceScopeFactory scopeFactory, ILogger<LibraryHub> logger)
        {
            _mediator = mediator;
            _backgroundTaskQueue = backgroundTaskQueue;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task<List<Series>> GetBooks()
        {
            var files = await _mediator.Send(new GetAudiobookFilesRequest());
            return files;
        }

        public async Task RefreshLibrary()
        {
            _logger.LogInformation("Refresh Library");
            await Clients.All.LibraryUpdated(new LibraryUpdate(10,5));
            _logger.LogInformation("Refresh Library2");
            //            _backgroundTaskQueue.QueueBackgroundWorkItem(async token =>
            //            {
            //                // create new scope, otherwise it uses the scope used for this request and the database is closed before it can be processed
            //                using var scope = _scopeFactory.CreateScope();
            //                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            //                await mediator.Send(new RefreshLibraryRequest(), token);
            //            });
            //            return Task.CompletedTask;
        }
    }
}