namespace Library.Models.UserMovieRatings
{
    public class UserMovieRatingRead
    {
        public Guid Uid { get; set; }
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}