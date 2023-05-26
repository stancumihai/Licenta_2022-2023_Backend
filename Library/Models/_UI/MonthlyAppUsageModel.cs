using Library.Models.SeenMovie;

namespace Library.Models._UI
{
    public class MonthlyAppUsageModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public List<SeenMovieRead>? SeenMovies { get; set; }
    }
}