﻿namespace AudiobookLibrary.Core.Library.Models
{
    public class Part
    {
        public int Id { get; set; }
        public int? Track { get; set; }
        public string Filename { get; set; }
    }
}