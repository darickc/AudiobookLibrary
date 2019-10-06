using System.Collections.Generic;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles;
using AudiobookLibrary.Core.Library.Interactors.RefreshLibrary;
using AudiobookLibrary.Web.BackgroundTasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace AudiobookLibrary.Web.Hubs
{
    public class LibraryHub : Hub<ILibraryHub>
    {
        private readonly IMediator _mediator;
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IServiceScopeFactory _scopeFactory;

        public LibraryHub(IMediator mediator, IBackgroundTaskQueue taskQueue, IServiceScopeFactory scopeFactory)
        {
            _mediator = mediator;
            _taskQueue = taskQueue;
            _scopeFactory = scopeFactory;
        }

        public async Task<List<AudiobookFile>> GetBooks()
        {
            var files = await _mediator.Send(new GetAudiobookFilesRequest());
            return files;
        }

        public Task RefreshLibrary()
        {
            _taskQueue.QueueBackgroundWorkItem(async token =>
            {
                // create new scope, otherwise it uses the scope used for this request and the database is closed before it can be processed
                using var scope = _scopeFactory.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new RefreshLibraryRequest(), token);
            });
            return Task.CompletedTask;
        }
    }
}