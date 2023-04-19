using DAL.Core;
using DAL.Enums;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class Movies : DALObject, IMovies
    {
        public Movies(DatabaseContext context) : base(context)
        {
        }

        public List<Movie> GetPaginatedMovies(int pageNumber, int pageSize)
        {
            return _context.Movies.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
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
            Movie? movie = _context.Movies
                .FirstOrDefault(movie => movie.MovieId == movieId);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }

        public List<Movie> GetAllByPersonUid(Guid personGuid)
        {
            return _context.KnownFor
                .Where(knownFor => knownFor.PersonGUID == personGuid)
                .Select(kf => kf.Movie)
                .ToList();
        }

        public List<Movie> GetMoviesByGenre(string genre, int pageNumber, int pageSize)
        {
            List<Movie> movies = _context.Movies.ToList();
            List<Movie> resultList = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Genres.Split(",").Contains(genre))
                {
                    resultList.Add(movie);
                }
            }
            return resultList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<string> GetMovieGenres()
        {
            return Enum.GetNames(typeof(Genres)).ToList();
        }

        public List<Movie> GetMoviesHistory(string userUid, int pageNumber, int pageSize)
        {
            List<Guid> seenMoviesUids = _context.SeenMovies
                .Where(sm => sm.UserGUID == userUid)
                .Select(sm => sm.MovieGUID)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return _context.Movies
                .Where(m => seenMoviesUids.Contains(m.MovieGUID))
                .ToList();
        }

        public List<Movie> GetMoviesSubscription(string userUid, int pageNumber, int pageSize)
        {
            List<Guid> subscriptionsUids = _context.MovieSubscriptions
               .Where(sm => sm.UserGUID == userUid)
               .Select(sm => sm.MovieGUID)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToList();
            return _context.Movies
                .Where(m => subscriptionsUids.Contains(m.MovieGUID))
                .ToList();
        }

        public List<Movie> GetMoviesCollection(string userUid, int pageNumber, int pageSize)
        {
            List<Guid> likedMoviesUids = _context.LikedMovies
              .Where(sm => sm.UserGUID == userUid)
              .Select(sm => sm.MovieGUID)
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToList();

            return _context.UserMovieRatings
               .Where(umr => likedMoviesUids.Contains(umr.MovieGUID) && umr.Rating > 8)
               .Select(umr => umr.Movie)
                .ToList();
        }
    }
}