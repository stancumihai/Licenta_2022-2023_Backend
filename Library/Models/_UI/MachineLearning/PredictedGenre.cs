namespace Library.Models._UI.MachineLearning
{
    public class PredictedGenre
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public List<GenreMonthlyCount> GenreMonthlyCounts { get; set; } = new();
    }

    public class GenreMonthlyCount
    {
        public string Genre { get; set; }
        public int Count { get; set; }
    };
}