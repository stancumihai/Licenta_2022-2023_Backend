using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UserMovieSearch
    {
        [Key]
        public Guid UserMovieSearchGUID { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieGUID { get; set; }
        [ForeignKey("User")]
        public string UserGUID { get; set; }
        public Movie Movie { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}