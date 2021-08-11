using AudiobookLibrary.Core.Library.Models;
using Microsoft.AspNetCore.Components;

namespace AudiobookLibrary.Web.Shared
{
    public partial class BookSeries
    {
        [Parameter]
        public Series Series { get; set; }

        public bool View { get; set; }

        protected override void OnParametersSet()
        {
            View = false;
        }
    }

}
