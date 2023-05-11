using Library.Models.SeenMovie;

namespace Library.Models
{
    public class MonthlyAppUsageModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public List<SeenMovieRead>? SeenMovies { get; set; }
    }
}
