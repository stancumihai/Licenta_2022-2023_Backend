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
        public User Add(User user)
        {
            User addedUser = _context.Users.Add(user).Entity;
            _context.SaveChanges();
            return addedUser;
        }
        public List<User> GetAll()
        {
            return _context.Users
                .Include(u => u.SurveyAnswers)
                .ToList();
        }
        public void Update(User user)
        {
            User? oldUser = _context.Users.FirstOrDefault(u => u.UserGUID.Equals(user.UserGUID));
            if (oldUser == null)
            {
                return;
            }
            UpdateFields(oldUser, user);
            _context.Users.Update(oldUser);
            _context.SaveChanges();
        }
        public void Delete(Guid uid)
        {
            User? user = _context.Users.Include(u => u.SurveyAnswers).FirstOrDefault(u => u.UserGUID.Equals(uid));
            if (user == null)
            {
                return;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            List<User> users = _context.Users.ToList();
            foreach (User user in users)
            {
                _context.Users.Remove(user);
            }
            _context.SaveChanges();
        }
        public User? GetByUid(Guid uid)
        {
            User? user = _context.Users.Include(u => u.SurveyAnswers).FirstOrDefault(u => u.UserGUID.Equals(uid));
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public User? GetByEmail(string email)
        {
            User? user = _context.Users.Include(u => u.SurveyAnswers).FirstOrDefault(u => u.Email.Equals(email));
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public User? GetByRefreshToken(string refreshToken)
        {
            User? user = _context.Users.Include(u => u.SurveyAnswers).FirstOrDefault(u => u.RefreshToken.Equals(refreshToken));
            if (user == null)
            {
                return null;
            }
            return user;
        }
        private static void UpdateFields(User oldUser, User newUser)
        {
            oldUser.Email = newUser.Email;
            oldUser.Password = newUser.Password;
            oldUser.RefreshToken = newUser.RefreshToken;
            oldUser.TokenCreated = newUser.TokenCreated;
            oldUser.TokenExpires = newUser.TokenExpires;
        }
    }
}