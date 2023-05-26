namespace Library.Models.PredictedMovieCount
{
    public class PredictedMovieCountCreate
    {
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public float MovieCount { get; set; }
    }
}