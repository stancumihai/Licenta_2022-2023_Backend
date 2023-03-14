
using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class MovieRatings : DALObject, IMovieRatings
    {
        public MovieRatings(DatabaseContext context) : base(context)
        {
        }

        public MovieRating Add(MovieRating movieRating)
        {
            MovieRating addedMovieRating = _context.MovieRatings.Add(movieRating).Entity;
            _context.SaveChanges();
            return addedMovieRating;
        }

        public List<MovieRating> GetAll()
        {
            return _context.MovieRatings.Include(mr => mr.Movie).ToList();
        }

        public MovieRating? GetByMovieUid(Guid movieUid)
        {
            return _context.MovieRatings
                .Include(mr => mr.Movie)
                .FirstOrDefault(mr => mr.MovieGUID == movieUid);
        }

        public MovieRating? GetByUid(Guid uid)
        {
            return _context.MovieRatings
                .Include(mr => mr.Movie)
                .FirstOrDefault(mr => mr.MovieRatingGUID == uid);
        }
    }
}