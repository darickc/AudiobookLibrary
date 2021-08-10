using System.Collections.Generic;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Interactors;
using AudiobookLibrary.Shared.Models;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace AudiobookLibrary.Web.Pages
{
    public partial class Index
    {
        [Inject] public IMediator Mediator { get; set; }
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

        protected override async Task OnInitializedAsync()
        {
            UpdateNotification = new LibraryUpdate(true);
            // Hub.LibraryUpdated = LibraryUpdated;
            Loading = true;
            await  Mediator.Send(new GetAudiobookFilesRequest())
                .Tap(series => Series = series);
            // await Hub.Connect();
            // await GetBooks();
        }
    }
}
