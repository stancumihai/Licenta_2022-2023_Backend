using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }
        public ICollection<SurveyUserAnswer>? SurveyUserAnswers { get; set; }
        public List<UserMovieRating>? UserMovieRatings { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}