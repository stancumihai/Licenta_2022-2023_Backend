using Library.Models.SurveyAnswer;
using Library.Enums;

namespace Library.Models.Users
{
    public class UserRead
    {
        public Guid Uid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public ICollection<SurveyAnswerRead> SurveyAnswers { get; set; }
    }
}