﻿using Library.Models.Movie;

namespace Library.Models.MovieSubscription
{
    public class MovieSubscriptionRead
    {
        public Guid Uid { get; set; }
        public MovieRead Movie { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}