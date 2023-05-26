using Library.Models.SeenMovie;

namespace Library.Models._UI
{
    public class TopGenreModel
    {
        public string Genre { get; set; }
        public List<SeenMovieRead> SeenMovies { get; set; }
    }
}