using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUsers
    {
        ApplicationUser? GetByUid(Guid uid);
        ApplicationUser? GetByEmail(string email);
        List<ApplicationUser>? GetAll();
        void Update(ApplicationUser user);
        bool UserHasSurveyAnswers(string userUid);
    }
}