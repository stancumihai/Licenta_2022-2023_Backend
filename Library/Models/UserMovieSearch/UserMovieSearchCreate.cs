namespace Library.Models.UserMovieSearch
{
    public class UserMovieSearchCreate
    {
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}