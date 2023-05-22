namespace Library.MachineLearningModels
{
    public class PredictedMovies
    {
        public string UserUid { get; set; }
        public List<string> FavouriteActors { get; set; }
        public List<string> FavouriteDirectors { get; set; }
        public List<string> FavouriteGenres { get; set; }
        public List<Guid> SeenMoviesUid { get; set; }
        public List<Guid> LikedMoviesUid { get; set; }
        public List<Guid> WatchLaterMoviesUid { get; set; }
        public List<Guid> PredictedMoviesUid { get; set; }
    }
}