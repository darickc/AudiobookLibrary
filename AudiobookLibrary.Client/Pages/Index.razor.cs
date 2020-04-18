using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiobookLibrary.Client.Services;
using AudiobookLibrary.Shared.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace AudiobookLibrary.Client.Pages
{
    public partial class Index
    {
        public bool Loading { get; set; }
        public List<Series> Series { get; set; }
        public List<Series> TempSeries { get; set; }
        public List<Series> FilteredSeries { get; set; }
        public LibraryUpdate UpdateNotification { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string SeriesName { get; set; }
        public int PageSize { get; set; } = 25;
        public int PageIndex { get; set; }
        [Inject]
        protected HubService Hub { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UpdateNotification = new LibraryUpdate(true);
            Hub.LibraryUpdated = LibraryUpdated;
            Loading = true;
            await Hub.Connect();
            await GetBooks();
        }

        private async Task GetBooks()
        {
            Loading = true;
            StateHasChanged();
            Series = await Hub.GetBooks();
            Filter();
            Loading = false;
            StateHasChanged();
        }
        

        private async void LibraryUpdated(LibraryUpdate update)
        {
            UpdateNotification = update;
            StateHasChanged();
            if (update.Complete)
            {
                await GetBooks();
            }
        }
        
        public async void RefreshLibrary()
        {
            UpdateNotification.Count = 0;
            UpdateNotification.Complete = false;
            await Hub.RefreshLibrary();

//            UpdateNotification.Count = 0;
//            UpdateNotification.FilesComplete = 0;
//            UpdateNotification.Complete = false;
//
//            await Task.Delay(1000);
//            UpdateNotification.Count = 10;
//            UpdateNotification.FilesComplete = 0;
//            StateHasChanged();
//            while (UpdateNotification.FilesComplete < UpdateNotification.Count)
//            {
//                await Task.Delay(1000);
//                UpdateNotification.FilesComplete++;
//                UpdateNotification.Percent = (double)UpdateNotification.FilesComplete / UpdateNotification.Count;
//                StateHasChanged();
//            }
//
//            UpdateNotification.Complete = true;
//            StateHasChanged();
        }

        public void Filter()
        {
            var temp = Series.Where(s =>
                (string.IsNullOrEmpty(Author) ||
                 (s.Author?.Contains(Author, StringComparison.OrdinalIgnoreCase) ?? false)) &&
                (string.IsNullOrEmpty(SeriesName) || (s.Name?.Contains(SeriesName, StringComparison.OrdinalIgnoreCase) ?? false)) &&
                (string.IsNullOrEmpty(Title) || s.Books.Any(b=>b.Title?.Contains(Title, StringComparison.OrdinalIgnoreCase) ?? false))).ToList();
            foreach (var s in temp)
            {
                s.FilteredBooks = s.Books.Where(b =>
                    string.IsNullOrEmpty(Title) ||
                    (b.Title?.Contains(Title, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();
            }

            TempSeries = temp;
            PageIndex = 0;
            UpdateSeries();
        }

        public void ClearField(string field)
        {
            switch (field)
            {
                case "Author":
                    Author = "";
                    break;
                case "Title":
                    Title = "";
                    break;
                case "SeriesName":
                    SeriesName = "";
                    break;
            }

            Filter();
        }

        public void OnPage(MatPaginatorPageEvent e)
        {
            PageSize = e.PageSize;
            PageIndex = e.PageIndex;
            UpdateSeries();
        }

        public void UpdateSeries()
        {
            FilteredSeries = TempSeries.Skip(PageSize * PageIndex).Take(PageSize).ToList();
        }
    }

}
