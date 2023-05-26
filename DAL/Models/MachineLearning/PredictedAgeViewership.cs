using System.ComponentModel.DataAnnotations;

namespace DAL.Models.MachineLearning
{
    public class PredictedAgeViewership
    {
        [Key]
        public Guid PredictedAgeViewershipGUID { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Age { get; set; }
        public int MovieCount { get; set; }
    }
}