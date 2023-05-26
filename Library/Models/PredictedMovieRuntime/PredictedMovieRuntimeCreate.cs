namespace Library.Models.PredictedMovieRuntime
{
    public class PredictedMovieRuntimeCreate
    {
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public float MovieRuntime { get; set; }
    }
}