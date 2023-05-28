namespace Library.MachineLearningModels
{
    public class PredictedMovie
    {
        public string UserEmail { get; set; }
        public string WatchLaterMovie { get; set; }
        public string LikedMovie { get; set; }
        public string CollectionMovie { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string MostWatchedGenre { get; set; } //all time
        public string MostWatchedMovie { get; set; } //all time
        public string PredictedGenre { get; set; }
        public string FuturePredictedMovie { get; set; }
    }
}