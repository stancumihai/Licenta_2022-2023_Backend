namespace Library.MachineLearningModels
{
    public class PredictedGenre
    {
        public string UserId { get; set; }
        public string AverageGenre1 { get; set; }
        public string AverageGenre2 { get; set; }
        public string MyAverageGenre1 { get; set; }
        public string MyAverageGenre2 { get; set; }
        public string AverageDirector { get; set; }
        public string MyAverageDirector { get; set; }
        public int Clicks { get; set; }
        public decimal AverageRating { get; set; }
        public decimal MyAverageRating { get; set; }
        public string FuturePredictedGenre { get; set; }
    }
}