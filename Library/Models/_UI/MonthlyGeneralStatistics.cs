namespace Library.Models._UI
{
    public class MonthlyGeneralStatistics
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int PersonCount { get; set; }
        public int RecommendationsCount { get; set; }
        public List<MonthlyRecommendationStatusModel> Statuses { get; set; }
    }
}