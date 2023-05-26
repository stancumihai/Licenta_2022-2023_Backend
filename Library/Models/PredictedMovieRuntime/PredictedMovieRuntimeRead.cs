namespace Library.Models.PredictedMovieRuntime
{
    public class PredictedMovieRuntimeRead
    {
        public Guid Uid { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public float MovieRuntime { get; set; }
    }
}