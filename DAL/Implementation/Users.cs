using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class Users : DALObject, IUsers
    {
        public Users(DatabaseContext context) : base(context)
        {
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.Users
                .Include(u => u.SurveyUserAnswers)!
                .ThenInclude(sua => sua.SurveyQuestion)
                .ToList();
        }

        public ApplicationUser? GetByUid(Guid uid)
        {
            return _context.Users
                .Include(u => u.SurveyUserAnswers)!
                .ThenInclude(sua => sua.SurveyQuestion)
                .FirstOrDefault(u => u.Id == uid.ToString());
        }

        public ApplicationUser? GetByEmail(string email)
        {
            return _context.Users
                .Include(u => u.SurveyUserAnswers)
                .FirstOrDefault(u => u.Email == email);
        }

        public void Update(ApplicationUser user)
        {
            ApplicationUser? oldUser = _context.Users.FirstOrDefault(u => u.Id.Equals(user.Id));
            if (oldUser == null)
            {
                return;
            }
            UpdateFields(oldUser, user);
            _context.Users.Update(oldUser);
            _context.SaveChanges();
        }

        public bool UserHasSurveyAnswers(string userUid)
        {
            return _context.SurveyUserAnswers
                .Where(sua => sua.UserGUID == userUid)!.Select(sua => sua.UserGUID)
                .ToList().Count > 0;
        }


        private static void UpdateFields(ApplicationUser oldUser, ApplicationUser newUser)
        {
            oldUser.Email = newUser.Email;
            oldUser.Password = newUser.Password;
            oldUser.RefreshToken = newUser.RefreshToken;
            oldUser.RefreshTokenExpiryTime = newUser.RefreshTokenExpiryTime;
            //oldUser.SurveyAnswers = newUser.SurveyAnswers;
        }
    }
}