using Library.Enums;

namespace Library.Models.Users
{
    public class UserRead
    {
        public Guid Uid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public List<SurveyUserAnswerRead>? SurveyUserAnswers { get; set; }
    }
}