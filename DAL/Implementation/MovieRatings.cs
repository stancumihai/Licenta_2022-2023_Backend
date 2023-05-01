
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
            MovieRating? movieRating = _context.MovieRatings
                .Include(mr => mr.Movie)
                .FirstOrDefault(mr => mr.MovieGUID == movieUid);
            if (movieRating == null)
            {
                return null;
            }
            return movieRating;
        }

        public MovieRating? GetByUid(Guid uid)
        {
            MovieRating? movieRating = _context.MovieRatings
                .Include(mr => mr.Movie)
                .FirstOrDefault(mr => mr.MovieRatingGUID == uid);
            if (movieRating == null)
            {
                return null;
            }
            return movieRating;
        }

        public MovieRating? Update(MovieRating newMovieRating)
        {
            MovieRating? oldMovieRating = _context.MovieRatings
                 .Include(mr => mr.Movie)
                 .FirstOrDefault(mr => mr.MovieRatingGUID == newMovieRating.MovieRatingGUID);
            if (oldMovieRating == null)
            {
                return null;
            }
            UpdateFields(oldMovieRating, newMovieRating);
            _context.MovieRatings.Update(oldMovieRating);
            _context.SaveChanges();
            return newMovieRating;
        }

        private void UpdateFields(MovieRating oldMovieRating, MovieRating newMovieRating)
        {
            oldMovieRating.MovieGUID = newMovieRating.MovieGUID;
            oldMovieRating.AverageRating = newMovieRating.AverageRating;
            oldMovieRating.VotesNumber = newMovieRating.VotesNumber;
        }
    }
}