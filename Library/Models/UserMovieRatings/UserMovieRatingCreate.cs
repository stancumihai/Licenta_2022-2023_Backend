namespace Library.Models.UserMovieRatings
{
    public class UserMovieRatingCreate
    {
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
        public decimal Rating { get; set; }
    }
}