using DAL.Core;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class UserMovieSearches : DALObject, IUserMovieSearches
    {
        public UserMovieSearches(DatabaseContext context) : base(context)
        {

        }
        public UserMovieSearch? Add(UserMovieSearch userMovieSearch)
        {
            ApplicationUser? existingUser = _context.Users.Find(userMovieSearch.UserGUID);
            if (existingUser == null)
            {
                return null;
            }
            Movie? existingMovie = _context.Movies.Find(userMovieSearch.MovieGUID);
            if (existingMovie == null)
            {
                return null;
            }
            UserMovieSearch addedUserMovieSearch = _context.UserMovieSearches.Add(userMovieSearch).Entity;
            _context.SaveChanges();
            return addedUserMovieSearch;
        }
    }
}