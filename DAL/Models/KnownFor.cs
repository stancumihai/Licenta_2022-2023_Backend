using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class KnownFor
    {
        [Key]
        public Guid KnownForGUID { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieGUID { get; set; }
        public Movie Movie { get; set; }
        [ForeignKey("Person")]
        public Guid PersonGUID { get; set; }
        public Person Person { get; set; }
    }
}