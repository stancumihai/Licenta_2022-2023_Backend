namespace Library.MachineLearningModels
{
    public class PredictedMovieRuntime
    {
        public string UserId { get; set; }
        public float AverageRuntime { get; set; }
        public float MyAverageRuntime { get; set; }
        public float AverageWatchLaterMoviesRuntime { get; set; }
        public int MyAverageWatchLaterMoviesRuntime { get; set; }
        public float AverageMovieClicks { get; set; }
        public int MyMovieClicks { get; set; }
        public decimal FuturePredictedRuntime { get; set; }
    }
}