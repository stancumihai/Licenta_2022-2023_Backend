namespace Library.MachineLearningModels
{
    public class PredictedMovieCount
    {
        public string UserId { get; set; }
        public float AverageMovieCount { get; set; }
        public int MyAverageMovieCount { get; set; }
        public float AverageWatchLaterMovies { get; set; }
        public int MyAverageWatchLaterMovies { get; set; }
        public float AverageMovieClicks { get; set; }
        public int MyMovieClicks { get; set; }
        public float FuturePredictedMovieCount { get; set; }
    }
}