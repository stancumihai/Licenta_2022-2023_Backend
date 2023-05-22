namespace Library.Models.PredictedMovieCount
{
    public class PredictedMovieCountRead
    {
        public Guid Uid { get; set; }
        public string UserUid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MovieCount { get; set; }
    }
}