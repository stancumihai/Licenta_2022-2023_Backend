using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UserProfile
    {
        [Key]
        public Guid UserProfileGUID { get; set; }
        [ForeignKey("User")]
        public string UserGUID { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}