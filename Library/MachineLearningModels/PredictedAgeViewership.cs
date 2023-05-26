namespace Library.MachineLearningModels
{
    public class PredictedAgeViewership
    {
        public int Age { get; set; }
        public int WatchLaterMoviesByAge { get; set; }
        public int SeenMoviesByAge { get; set; }
        public int ClicksByAge { get; set; }
        public int FuturePredictedMoviesCount { get; set; }
    }
}