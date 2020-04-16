using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AudiobookLibrary.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace AudiobookLibrary.Client.Services
{
    public class HubService
    {
        private readonly HubConnection _hub;
        public Action<LibraryUpdate> LibraryUpdated { get; set; }

        public HubService(NavigationManager navigationManager)
        {
            _hub = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/library"))
                .Build();

            _hub.On<LibraryUpdate>("LibraryUpdate", e => LibraryUpdated?.Invoke(e));
        }

        public Task Connect()
        {
            return _hub.StartAsync();
        }

        public Task<List<Series>> GetBooks()
        {
            return _hub.InvokeAsync<List<Series>>(nameof(GetBooks));
        }

        public Task RefreshLibrary()
        {
            return _hub.InvokeAsync(nameof(RefreshLibrary));
        }
    }
}