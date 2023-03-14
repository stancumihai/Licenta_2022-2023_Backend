using Library.Models.Movie;

namespace Library.Models.MovieRating
{
    public class MovieRatingRead
    {
        public Guid Uid { get; set; }
        public MovieRead? Movie { get; set; }
        public decimal AverageRating { get; set; }
        public long VotesNumber { get; set; }
    }
}