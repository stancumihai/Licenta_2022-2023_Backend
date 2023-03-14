using DAL.Core;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class Movies : DALObject, IMovies
    {
        public Movies(DatabaseContext context) : base(context)
        {
        }

        public Movie Add(Movie movie)
        {
            Movie addedMovie = _context.Movies.Add(movie).Entity;
            _context.SaveChanges();
            return addedMovie;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetByUid(Guid movieUid)
        {
            return _context.Movies
                .FirstOrDefault(movie => movie.MovieGUID == movieUid);
        }

        public Movie? GetByMovieId(string movieId)
        {
            return _context.Movies
                .FirstOrDefault(movie => movie.MovieId == movieId);
        }
    }
}