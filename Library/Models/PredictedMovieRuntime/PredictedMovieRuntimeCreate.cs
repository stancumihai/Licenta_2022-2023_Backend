namespace Library.Models.PredictedMovieRuntime
{
    public class PredictedMovieRuntimeCreate
    {
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MovieRuntime { get; set; }
    }
}