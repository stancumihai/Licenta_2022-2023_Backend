using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class MovieRating
    {
        [Key]
        public Guid MovieRatingGUID { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieGUID { get; set; }
        public Movie? Movie { get; set; }
        public decimal AverageRating { get; set; }
        public long VotesNumber { get; set; }
    }
}