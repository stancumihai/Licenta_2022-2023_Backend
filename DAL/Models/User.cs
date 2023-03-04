using DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public Guid UserGUID { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public Roles Role { get; set; }
        public ICollection<SurveyAnswer> SurveyAnswers { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}