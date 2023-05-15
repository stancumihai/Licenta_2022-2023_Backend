using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class MovieSubscriptions : DALObject, IMovieSubscriptions
    {
        public MovieSubscriptions(DatabaseContext context) : base(context)
        {
        }

        public MovieSubscription Add(MovieSubscription movieSubscription)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == movieSubscription.UserGUID);
            if (user == null)
            {
                return null;
            }
            Movie? movie = _context.Movies.FirstOrDefault(m => m.MovieGUID == movieSubscription.MovieGUID);
            if (movie == null)
            {
                return null;
            }
            MovieSubscription addedMovieSubscription = _context.MovieSubscriptions.Add(movieSubscription).Entity;
            _context.SaveChanges();
            return addedMovieSubscription;
        }

        public MovieSubscription Delete(Guid uid)
        {
            MovieSubscription? movieSubscription = _context.MovieSubscriptions
             .Include(ms => ms.Movie)
             .FirstOrDefault(ms => ms.MovieSubscriptionGUID == uid);
            if (movieSubscription == null)
            {
                return null;
            }
            _context.MovieSubscriptions.Remove(movieSubscription);
            _context.SaveChanges();
            return movieSubscription;
        }

        public List<MovieSubscription> GetAll()
        {
            return _context
                .MovieSubscriptions
                .Include(ms => ms.Movie)
                .ToList();
        }

        public List<MovieSubscription> GetAllByUser(string userUid)
        {
            return _context
                .MovieSubscriptions
                 .Include(ms => ms.Movie)
                .Where(m => m.UserGUID == userUid)
                .ToList();
        }

        public MovieSubscription? GetByUid(Guid uid)
        {
            MovieSubscription? movieSubscription = _context.MovieSubscriptions
                       .Include(l => l.Movie)
                       .FirstOrDefault(ms => ms.MovieSubscriptionGUID == uid);
            if (movieSubscription == null)
            {
                return null;
            }
            return movieSubscription!;
        }

        public MovieSubscription GetByUserAndMovie(Guid movieUid, string userGUID)
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
            return _context.MovieSubscriptions
                .Include(l => l.Movie).Where(l => l.UserGUID == userGUID && l.MovieGUID == movieUid)
                .FirstOrDefault()!;
        }
    }
}