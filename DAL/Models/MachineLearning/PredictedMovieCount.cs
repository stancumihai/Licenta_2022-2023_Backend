using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.MachineLearning
{
    public class PredictedMovieCount
    {
        [Key]
        public Guid PredictedMovieCountGUID { get; set; }
        [ForeignKey("User")]
        public string UserGUID { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }
        public float MovieCount { get; set; }
    }
}