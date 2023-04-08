namespace Library.Models.LikedMovie
{
    public class LikedMovieCreate
    {
        public Guid MovieUid { get; set; }
        public string UserUid { get; set; }
    }
}