namespace Library.Models.MovieRating
{
    public class MovieRatingCreate
    {
        public Guid MovieRatingUid { get; set; }
        public decimal AverageRating { get; set; }
        public long VotesNumber { get; set; }
    }
}