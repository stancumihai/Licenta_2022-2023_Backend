using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class LikedMovies : DALObject, ILikedMovies
    {
        public LikedMovies(DatabaseContext context) : base(context)
        {
        }

        public LikedMovie? Add(LikedMovie likedMovie)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == likedMovie.UserGUID);
            if(user == null)
            {
                return null;
            }
            Movie? movie = _context.Movies.FirstOrDefault(m => m.MovieGUID == likedMovie.MovieGUID);
            if (movie == null)
            {
                return null;
            }
            LikedMovie? addedLikedMovie = _context.LikedMovies.Add(likedMovie).Entity;
            _context.SaveChanges();
            return addedLikedMovie;
        }

        public void Delete(Guid uid)
        {
            LikedMovie? likedMovie = _context.LikedMovies
             .Include(l => l.Movie)
             .FirstOrDefault(l => l.LikedMovieGUID == uid);
            if (likedMovie == null)
            {
                return;
            }
            _context.LikedMovies.Remove(likedMovie);
            _context.SaveChanges();
        }

        public List<LikedMovie> GetAll()
        {
            return _context.LikedMovies.Include(l => l.Movie).ToList();
        }

        public LikedMovie? GetByUid(Guid uid)
        {
            LikedMovie? likedMovie = _context.LikedMovies
               .Include(l => l.Movie)
               .FirstOrDefault(l => l.LikedMovieGUID == uid);
            if (likedMovie == null)
            {
                return null;
            }
            return likedMovie!;
        }

        public List<LikedMovie> GetAllByLoggedUser(string userGUID)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == userGUID);
            if (user == null)
            {
                return null;
            }
            return _context.LikedMovies
                .Include(l => l.Movie).Where(l => l.UserGUID == userGUID)
                .ToList();
        }

        public LikedMovie GetByUserAndMovie(Guid movieUid, string userGUID)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == userGUID);
            if (user == null)
            {
                return null;
            }
            Movie? movie = _context.Movies.FirstOrDefault(m => m.MovieGUID == movieUid);
            if (movie == null)
            {
                return null;
            }
            return _context.LikedMovies
                .Include(l => l.Movie).Where(l => l.UserGUID == userGUID && l.MovieGUID == movieUid)
                .FirstOrDefault()!;
        }
    }
}