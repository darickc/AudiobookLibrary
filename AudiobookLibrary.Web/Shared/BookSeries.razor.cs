using AudiobookLibrary.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace AudiobookLibrary.Web.Shared
{
    public partial class BookSeries
    {
        [Parameter]
        public Series Series { get; set; }

        public bool View { get; set; }
    }

}
