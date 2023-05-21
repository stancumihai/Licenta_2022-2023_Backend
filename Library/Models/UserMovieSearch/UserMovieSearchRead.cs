namespace Library.Models.UserMovieSearch
{
    public class UserMovieSearchRead
    {
        public Guid Uid { get; set; }
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}