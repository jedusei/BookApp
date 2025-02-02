﻿namespace BookApp.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public string WebUrl { get; set; }
        public float Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}
