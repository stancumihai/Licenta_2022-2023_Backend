namespace Library.Models.UserMovieRatings
{
    public class UserMovieRatingsCreate
    {
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
        private decimal Rating { get; set; }
    }
}