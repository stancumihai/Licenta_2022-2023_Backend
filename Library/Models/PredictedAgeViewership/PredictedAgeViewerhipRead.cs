namespace Library.Models.PredictedAgeViewership
{
    public class PredictedAgeViewershipRead
    {
        public Guid Uid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Age { get; set; }
        public int MovieCount { get; set; }
    }
}