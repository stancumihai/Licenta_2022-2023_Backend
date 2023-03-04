using Library.Models.SurveyAnswer;
using Library.Enums;

namespace Library.Models.Users
{
    public class UserRead
    {
        public Guid Uid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        //public ICollection<SurveyAnswerRead>? SurveyAnswers { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}