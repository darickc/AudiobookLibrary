using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Interactors;
using AudiobookLibrary.Core.Library.Models;
using AudiobookLibrary.Core.Library.Notifications;
using AudiobookLibrary.Core.Library.Services;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AudiobookLibrary.Web.Pages
{
    public partial class Index
    {
        [Inject] public IMediator Mediator { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public NotificationService NotificationService { get; set; }
        public bool Loading { get; set; }
        public List<Series> Series { get; set; }
        public LibraryUpdate UpdateNotification { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string SeriesName { get; set; }
        public int PageSize { get; set; } = 12;
        public int PageIndex { get; set; } = 1;
        public int PageCount { get; set; }

        protected override async Task OnInitializedAsync()
        {
            NotificationService.LibraryUpdated = LibraryUpdated;
            UpdateNotification = new LibraryUpdate(true);
            await GetBooks();
        }

        public async Task GetBooks()
        {
            await GetBooks(false);
        }

        public async Task GetBooks(bool paging)
        {
            if (!paging)
            {
                PageIndex = 1;
            }
            Loading = true;
            await Mediator.Send(new GetAudiobookFilesRequest(Title, Author, SeriesName, PageIndex, PageSize))
                .Tap(r => Series = r.Series)
                .Tap(r=>PageIndex = r.Page)
                .Tap(r=> PageCount = r.PageCount)
                .OnFailure(e => Snackbar.Add(e, Severity.Error))
                .Finally(r => Loading = false);
            await InvokeAsync(StateHasChanged);
        }

        private async void LibraryUpdated(LibraryUpdate update)
        {
            await InvokeAsync(async () =>
            {
                UpdateNotification = update;
                StateHasChanged();
                if (update.Complete)
                {
                    await GetBooks();
                }
            });
        }

        public async Task NextPage()
        {
            PageIndex++;
            await GetBooks(true);
        }

        public async Task PrevPage()
        {
            PageIndex--;
            await GetBooks(true);
        }

        public async Task FirstPage()
        {
            PageIndex = 1;
            await GetBooks(true);
        }

        public async Task LastPage()
        {
            PageIndex = PageCount;
            await GetBooks(true);
        }

    }
}
