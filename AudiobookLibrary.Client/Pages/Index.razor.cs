using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AudiobookLibrary.Client.Services;
using AudiobookLibrary.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace AudiobookLibrary.Client.Pages
{
    public partial class Index
    {
        public bool Loading { get; set; }
        public List<Series> Series { get; set; }
        public LibraryUpdate UpdateNotification { get; set; }
        public string Author { get; set; }
        [Inject]
        protected HubService Hub { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UpdateNotification = new LibraryUpdate(true);

            Hub.LibraryUpdated = LibraryUpdated;
            Loading = true;
            await Hub.Connect();
        }

        private void LibraryUpdated(LibraryUpdate update)
        {
            UpdateNotification = update;
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Series = await Hub.GetBooks();
            Loading = false;
            StateHasChanged();
        }

        public async void RefreshLibrary()
        {
            await Hub.RefreshLibrary();
        }

    }
}
