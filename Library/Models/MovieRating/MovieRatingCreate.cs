namespace Library.Models.MovieRating
{
    public class MovieRatingCreate
    {
        public Guid MovieUid { get; set; }
        public decimal AverageRating { get; set; }
        public long VotesNumber { get; set; }
    }
}