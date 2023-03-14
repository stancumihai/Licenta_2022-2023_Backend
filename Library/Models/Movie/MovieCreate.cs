﻿namespace Library.Models.Movie
{
    public class MovieCreate
    {
        public string MovieId { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int Runtime { get; set; }
        public string Genres { get; set; }
    }
}