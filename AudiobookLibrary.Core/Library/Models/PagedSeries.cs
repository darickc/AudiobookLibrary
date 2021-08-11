using System.Collections.Generic;

namespace AudiobookLibrary.Core.Library.Models
{
    public class PagedSeries
    {
        public List<Series> Series { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
    }
}