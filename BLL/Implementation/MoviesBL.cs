using BLL.Converters.Movie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models;
using Library.Models.Movie;
using Library.Models.MovieRating;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class MoviesBL : BusinessObject, IMovies
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MoviesBL(DAL.Interfaces.IDALContext dalContext,
            IHttpContextAccessor httpContextAccessor) : base(dalContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public MovieCreate Add(MovieCreate movie)
        {
            Movie addedMovie = MovieCreateConverter.ToDALModel(movie);
            return MovieCreateConverter.ToBLLModel(_dalContext.Movies.Add(addedMovie));
        }

        public List<MovieRead> GetAll()
        {
            return _dalContext.Movies
                .GetAll()
                .Select(movie => MovieReadConverter.ToBLLModel(movie))
                .ToList();
        }

        public MovieRead? GetByMovieId(string movieId)
        {
            Movie? movie = _dalContext.Movies
                 .GetByMovieId(movieId)!;
            if (movie == null)
            {
                return null;
            }
            return MovieReadConverter
                 .ToBLLModel(movie);
        }

        public MovieRead? GetByUid(Guid uid)
        {
            return MovieReadConverter
                .ToBLLModel(_dalContext.Movies
                .GetByUid(uid)!);
        }

        public List<MovieRead> GetPaginatedMovies(int pageNumber, int pageSize)
        {
            return _dalContext.Movies
                .GetPaginatedMovies(pageNumber, pageSize)
                .Select(movie => MovieReadConverter.ToBLLModel(movie))
                .ToList();
        }

        public List<MovieRead> GetAllByPersonUid(Guid personGuid)
        {
            return _dalContext.Movies
               .GetAllByPersonUid(personGuid)
               .Select(movie => MovieReadConverter.ToBLLModel(movie))
               .ToList();
        }

        public List<MovieRead> GetMoviesByGenrePaginated(string genre, int pageNumber, int pageSize)
        {
            return _dalContext.Movies
               .GetMoviesByGenre(genre, pageNumber, pageSize)
               .Select(movie => MovieReadConverter.ToBLLModel(movie))
               .ToList();
        }

        public List<string> GetMovieGenres()
        {
            return _dalContext.Movies.GetMovieGenres();
        }

        public List<MovieRead> GetMoviesHistoryPaginated(int pageNumber, int pageSize)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesHistoryPaginated(userEntity.Id, pageNumber, pageSize)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<MovieRead> GetMoviesSubscriptionPaginated(int pageNumber, int pageSize)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesSubscriptionPaginated(userEntity.Id, pageNumber, pageSize)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<MovieRead> GetMoviesCollectionPaginated(int pageNumber, int pageSize)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesCollectionPaginated(userEntity.Id, pageNumber, pageSize)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<MovieRead> GetMoviesHistory()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesHistory(userEntity.Id)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<MovieRead> GetMoviesSubscription()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesSubscription(userEntity.Id)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<MovieRead> GetMoviesCollection()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            List<MovieRead> moviesCollection = _dalContext.Movies
              .GetMoviesCollection(userEntity.Id)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
            return moviesCollection;
        }

        public List<MovieRead> GetAllMoviesCollectionByUser(string userUid)
        {
            return _dalContext.Movies
              .GetMoviesCollection(userUid)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<string> GetTopLikedGenres()
        {
            List<Movie> toSearchInMovies = new(_dalContext
                                                    .LikedMovies
                                                    .GetAll()
                                                    .Select(l => l.Movie).ToList()
                                                        .Concat(_dalContext
                                                                    .SeenMovies
                                                                    .GetAll()
                                                                    .Select(s => s.Movie)
                                                                    .ToList()));
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            IDictionary<string, int> genresDictionary = new Dictionary<string, int>();

            for (int i = 0; i < genres.Count; i++)
            {
                genresDictionary.Add(genres[i], 0);
            }
            foreach (Movie movie in toSearchInMovies)
            {
                string[] movieGenres = movie.Genres.Split(',');
                foreach (string genre in movieGenres)
                {
                    if(genre == "Sci-Fi")
                    {
                        string scifiGenre = "SciFi";
                        genresDictionary[scifiGenre]++;
                        continue;
                    }
                    genresDictionary[genre]++;
                }
            }
            IEnumerable<string> mostappreciatedPersonsSortedGenres = from genresDicEntry in genresDictionary
                                                                     orderby genresDicEntry.Value
                                                                     descending
                                                                     select genresDicEntry.Key;
            return mostappreciatedPersonsSortedGenres.Take(4).ToList();
        }

        private List<Movie> GetMoviesByOrderByStrategy(List<Movie> movies, string orderByStrategy, bool isAscending, int itemsPerPage)
        {
            if (orderByStrategy == "Release Date")
            {
                if (isAscending)
                {
                    return (from movie in movies orderby movie.YearOfRelease ascending select movie).Take(itemsPerPage).ToList();
                }
                return (from movie in movies orderby movie.YearOfRelease descending select movie).Take(itemsPerPage).ToList();
            }

            List<MovieRating> movieRatings = new();
            if (isAscending)
            {

                movieRatings = (from moveRating in _dalContext.MovieRatings.GetAll() orderby moveRating.AverageRating ascending select moveRating).ToList();
            }
            else
            {
                movieRatings = (from moveRating in _dalContext.MovieRatings.GetAll() orderby moveRating.AverageRating descending select moveRating).ToList();
            }
            List<Movie> movieList = new();
            foreach (MovieRating rating in movieRatings)
            {
                Movie? existingMovie = movies.FirstOrDefault(r => r.MovieGUID == rating.MovieGUID);
                if (existingMovie != null)
                {
                    movieList.Add(existingMovie);
                    if (movieList.Count == itemsPerPage)
                    {
                        break;
                    }
                }
            }
            return movieList;
        }

        public List<MovieRead> GetAdvancedSearchMovies(SearchModel searchModel)
        {
            List<Movie> filteredMovies = _dalContext
                .Movies
                .GetAll()
                .Where(m => m.YearOfRelease >= searchModel.MinYear &&
                       m.YearOfRelease <= searchModel.MaxYear)
                .ToList();

            if (searchModel.Genre != "")
            {
                filteredMovies = filteredMovies.Where(m => m.Genres.Split(',').Contains(searchModel.Genre)).ToList();
            }
            if (searchModel.Director == "" && searchModel.Actor == "")
            {
                filteredMovies = GetMoviesByOrderByStrategy(filteredMovies, searchModel.OrderBy, searchModel.Ordering == "A", searchModel.ItemsPerPage);
                filteredMovies = filteredMovies
                    .ToList();

                return filteredMovies.Select(m => MovieReadConverter.ToBLLModel(m)).ToList();
            }
            List<Person> persons = new();
            if (searchModel.Director != "")
            {
                persons = _dalContext.Persons.GetAll().Where(p =>
                     (p.Name == searchModel.Actor && p.Professions.Split(",").Contains("actor"))).ToList();
            }
            if (searchModel.Actor != "")
            {
                persons.AddRange(_dalContext.Persons.GetAll().Where(p =>
                    (p.Name == searchModel.Director && p.Professions.Split(",").Contains("director"))).ToList());
            }

            List<Movie> moviePersons = new();
            foreach (Person person in persons)
            {
                moviePersons.AddRange(_dalContext.Movies.GetAllByPersonUid(person.PersonGUID).DistinctBy(m => m.MovieId));
            }
            filteredMovies = filteredMovies
               .Intersect(moviePersons)
               .ToList();
            filteredMovies = GetMoviesByOrderByStrategy(filteredMovies, searchModel.OrderBy, searchModel.Ordering == "A", searchModel.ItemsPerPage);
            
            return filteredMovies.Select(e => MovieReadConverter.ToBLLModel(e)).ToList();
        }
    }
}