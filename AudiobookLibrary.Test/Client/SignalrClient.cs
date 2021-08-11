using System;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Xunit;

namespace AudiobookLibrary.Test.Client
{
    public class SignalrClient
    {
        private readonly HubConnection _hub;

        public SignalrClient()
        {
            _hub = new HubConnectionBuilder()
                .WithUrl("https://localhost:44315/library")
                .Build();
            
            _hub.On<LibraryUpdate>("LibraryUpdated", e =>
            {
            });
        }

        [Fact]
        public async Task TestNotification()
        {
            await _hub.StartAsync();
            await _hub.InvokeAsync("RefreshLibrary");
            await Task.Delay(10000);
        }
    }
}