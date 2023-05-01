using Library.Models.Movie;

namespace Library.Models.SeenMovie
{
    public class SeenMovieRead
    {
        public Guid Uid { get; set; }
        public MovieRead Movie { get; set; }
        public string UserGUID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}