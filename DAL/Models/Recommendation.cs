using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Recommendation
    {
        [Key]
        public Guid RecommendationGUID { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieGUID { get; set; }
        [ForeignKey("User")]
        public string? UserGUID { get; set; }
        public Movie? Movie { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LikedDecisionDate { get; set; } = DateTime.MinValue;
        public bool IsLiked { get; set; } = false;
    }
}