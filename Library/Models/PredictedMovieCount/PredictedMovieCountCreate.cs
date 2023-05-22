namespace Library.Models.PredictedMovieCount
{
    public class PredictedMovieCountCreate
    {
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MovieCount { get; set; }
    }
}