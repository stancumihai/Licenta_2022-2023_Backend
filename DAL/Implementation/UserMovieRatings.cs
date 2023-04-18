using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class UserMovieRatings : DALObject, IUserMovieRatings
    {
        public UserMovieRatings(DatabaseContext context) : base(context)
        {

        }

        public UserMovieRating? Add(UserMovieRating userMovieRating)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id.Equals(userMovieRating.UserGUID));
            if (user == null)
            {
                return null;
            }
            Movie? movie = _context.Movies.FirstOrDefault(m => m.MovieGUID.Equals(userMovieRating.MovieGUID));
            if (movie == null)
            {
                return null;
            }
            UserMovieRating addedUserMovieRating = _context.UserMovieRatings.Add(userMovieRating).Entity;
            _context.SaveChanges();
            return addedUserMovieRating;
        }

        public void Delete(Guid guid)
        {
            UserMovieRating? userMovieRatingToBeDeleted = _context.UserMovieRatings
             .Include(l => l.Movie).Where(l => l.UserMovieRatingGUID == guid)
             .FirstOrDefault();
            if (userMovieRatingToBeDeleted == null)
            {
                return;
            }
            _context.UserMovieRatings.Remove(userMovieRatingToBeDeleted);
            _context.SaveChanges();
        }

        public List<UserMovieRating> GeAllByLoggedUser(string userGUID)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == userGUID);
            if (user == null)
            {
                return null;
            }
            return _context.UserMovieRatings
                .Include(l => l.Movie).Where(l => l.UserGUID == userGUID)
                .ToList();
        }

        public List<UserMovieRating> GetAll()
        {
            return _context.UserMovieRatings
               .Include(l => l.Movie)
               .ToList();
        }

        public UserMovieRating? GetByUid(Guid guid)
        {
            UserMovieRating? foundUserMovieRating = _context.UserMovieRatings
               .Include(l => l.Movie).Where(l => l.UserMovieRatingGUID == guid)
               .FirstOrDefault();
            if (foundUserMovieRating == null)
            {
                return null;
            }
            return foundUserMovieRating;
        }

        public UserMovieRating? Update(UserMovieRating newUserMovieRating)
        {
            UserMovieRating? oldUserMovieRating = _context.UserMovieRatings
             .Include(l => l.Movie).Where(l => l.UserMovieRatingGUID == newUserMovieRating.UserMovieRatingGUID)
             .FirstOrDefault();
            if (oldUserMovieRating == null)
            {
                return null;
            }
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id.Equals(newUserMovieRating.UserGUID));
            if (user == null)
            {
                return null;
            }
            Movie? movie = _context.Movies.FirstOrDefault(m => m.MovieGUID.Equals(newUserMovieRating.MovieGUID));
            if (movie == null)
            {
                return null;
            }
            UpdateFields(oldUserMovieRating, newUserMovieRating);
            _context.UserMovieRatings.Update(oldUserMovieRating);
            _context.SaveChanges();
            return newUserMovieRating;
        }

        private static void UpdateFields(UserMovieRating oldUserMovieRating, UserMovieRating newUserMovieRating)
        {
            oldUserMovieRating.MovieGUID = newUserMovieRating.MovieGUID;
            oldUserMovieRating.UserGUID = newUserMovieRating.UserGUID;
            oldUserMovieRating.Rating = newUserMovieRating.Rating;
        }
    }
}