namespace Library.Models.PredictedMovieCount
{
    public class PredictedMovieCountRead
    {
        public Guid Uid { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public float MovieCount { get; set; }
    }
}