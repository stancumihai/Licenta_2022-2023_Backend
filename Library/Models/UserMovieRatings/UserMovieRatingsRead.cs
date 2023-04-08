namespace Library.Models.UserMovieRatings
{
    public class UserMovieRatingsRead
    {
        public Guid Uid { get; set; }
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
        private decimal Rating { get; set; }
    }
}