using Library.Models.Movie;

namespace Library.Models.LikedMovie
{
    public class LikedMovieRead
    {
        public Guid Uid { get; set; }
        public MovieRead Movie { get; set; }
        public string UserGUID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
