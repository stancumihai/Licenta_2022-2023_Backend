namespace Library.Models.Excel
{
    public class MovieRating
    {
        public Guid MovieRatingGUID { get; set; }
        public string MovieId { get; set; }
        public decimal AverageRating { get; set; }
        public long VotesNumber { get; set; }
    }
}