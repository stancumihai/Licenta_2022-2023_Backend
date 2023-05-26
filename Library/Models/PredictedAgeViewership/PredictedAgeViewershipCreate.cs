namespace Library.Models.PredictedAgeViewership
{
    public class PredictedAgeViewershipCreate
    {
        public DateTime CreatedAt { get; set; }
        public int Age { get; set; }
        public int MovieCount { get; set; }
    }
}