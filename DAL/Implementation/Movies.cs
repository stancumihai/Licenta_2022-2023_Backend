using DAL.Comparers;
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

        public List<Movie> GetMoviesHistoryPaginated(string userUid, int pageNumber, int pageSize)
        {
            List<SeenMovie> seenMovies = _context.SeenMovies
                .ToList()
                .Distinct(new SeenMovieComparer())
                .ToList();

            List<Guid> seenMoviesUids = seenMovies
                .Where(sm => sm.UserGUID == userUid)
                .Select(sm => sm.MovieGUID)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return _context.Movies
                .Where(m => seenMoviesUids.Contains(m.MovieGUID))
                .ToList();
        }

        public List<Movie> GetMoviesSubscriptionPaginated(string userUid, int pageNumber, int pageSize)
        {
            List<MovieSubscription> movieSubscriptions = _context.MovieSubscriptions
                .ToList()
                .Distinct()
                .ToList();

            List<Guid> subscriptionsUids = movieSubscriptions
               .Where(sm => sm.UserGUID == userUid)
               .Select(sm => sm.MovieGUID)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            return _context.Movies
                .Where(m => subscriptionsUids.Contains(m.MovieGUID))
                .ToList();
        }

        public List<Movie> GetMoviesCollectionPaginated(string userUid, int pageNumber, int pageSize)
        {
            List<LikedMovie> likedMovies = _context.LikedMovies
               .ToList()
               .Distinct(new LikedMovieComparer())
               .ToList();

            List<Guid> likedMoviesUids = likedMovies
              .Where(sm => sm.UserGUID == userUid)
              .Select(sm => sm.MovieGUID)
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToList();

            var userMovieRatingsList = _context.UserMovieRatings
               .Where(umr => likedMoviesUids.Contains(umr.MovieGUID) && umr.Rating > (decimal)3.9)
               .Select(umr => umr.Movie)
                .ToList();
            return userMovieRatingsList;
        }

        public List<Movie> GetMoviesHistory(string userUid)
        {
            List<SeenMovie> seenMovies = _context.SeenMovies
              .ToList()
              .Distinct(new SeenMovieComparer())
              .ToList();

            List<Guid> seenMoviesUids = seenMovies
                .Where(sm => sm.UserGUID == userUid)
                .Select(sm => sm.MovieGUID)
                .ToList();

            return _context.Movies
                .Where(m => seenMoviesUids.Contains(m.MovieGUID))
                .ToList();
        }

        public List<Movie> GetMoviesSubscription(string userUid)
        {
            List<MovieSubscription> movieSubscriptions = _context.MovieSubscriptions
               .ToList()
               .Distinct(new MovieSubscriptionComparer())
               .ToList();


            List<Guid> subscriptionsUids = movieSubscriptions
                .Where(sm => sm.UserGUID == userUid)
                .Select(sm => sm.MovieGUID)
                .ToList();

            return _context.Movies
                .Where(m => subscriptionsUids.Contains(m.MovieGUID))
                .ToList();
        }

        public List<Movie> GetMoviesCollection(string userUid)
        {
            List<LikedMovie> likedMovies = _context.LikedMovies
               .ToList()
               .Distinct(new LikedMovieComparer())
               .ToList();

            List<Guid> likedMoviesUids = likedMovies
             .Where(sm => sm.UserGUID == userUid)
             .Select(sm => sm.MovieGUID)
             .ToList();

            return _context.UserMovieRatings
               .Where(umr => likedMoviesUids.Contains(umr.MovieGUID) && umr.Rating > (decimal)3.9)
               .Select(umr => umr.Movie)
                .ToList();
        }
    }
}