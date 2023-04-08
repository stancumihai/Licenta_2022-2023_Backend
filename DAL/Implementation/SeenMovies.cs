using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class SeenMovies : DALObject, ISeenMovies
    {
        public SeenMovies(DatabaseContext context) : base(context)
        {
        }

        public SeenMovie Add(SeenMovie seenMovie)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == seenMovie.UserGUID);
            if (user == null)
            {
                return null;
            }
            Movie? movie = _context.Movies.FirstOrDefault(m => m.MovieGUID == seenMovie.MovieGUID);
            if (movie == null)
            {
                return null;
            }
            SeenMovie addedSeenMovie = _context.SeenMovies.Add(seenMovie).Entity;
            _context.SaveChanges();
            return addedSeenMovie;
        }

        public SeenMovie Delete(Guid uid)
        {
            SeenMovie? seenMovie = _context.SeenMovies
             .Include(sm => sm.Movie)
             .FirstOrDefault(sm => sm.SeenMovieGUID == uid);
            if (seenMovie == null)
            {
                return null;
            }
            _context.SeenMovies.Remove(seenMovie);
            _context.SaveChanges();
            return seenMovie;
        }

        public List<SeenMovie> GetAll()
        {
            return _context.SeenMovies.Include(ms => ms.Movie).ToList();
        }

        public SeenMovie? GetByUid(Guid uid)
        {
            SeenMovie? seenMovie = _context.SeenMovies
                                   .Include(l => l.Movie)
                                   .FirstOrDefault(sm => sm.SeenMovieGUID == uid);
            if (seenMovie == null)
            {
                return null;
            }
            return seenMovie!;
        }

        public SeenMovie GetByUserAndMovie(Guid movieUid, string userGUID)
        {
            ApplicationUser user = _context.Users.FirstOrDefault(u => u.Id == userGUID);
            if (user == null)
            {
                return null;
            }
            Movie movie = _context.Movies.FirstOrDefault(m => m.MovieGUID == movieUid);
            if (movie == null)
            {
                return null;
            }
            return _context.SeenMovies
                .Include(sm => sm.Movie).Where(sm => sm.UserGUID == userGUID && sm.MovieGUID == movieUid)
                .FirstOrDefault()!;
        }
    }
}