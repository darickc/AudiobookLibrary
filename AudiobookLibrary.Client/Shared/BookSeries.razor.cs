﻿using AudiobookLibrary.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace AudiobookLibrary.Client.Shared
{
    public partial class BookSeries
    {
        [Parameter]
        public Series Series { get; set; }
        
        public bool ShowBooks { get; set; }
        
        public void ShowBooksClick()
        {
            ShowBooks = !ShowBooks;
        }
    }
}
