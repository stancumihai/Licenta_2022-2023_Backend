using BLL.Converters.Movie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.Movie;
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

        public List<MovieRead> GetMoviesByGenre(string genre, int pageNumber, int pageSize)
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

        public List<MovieRead> GetMoviesHistory(int pageNumber, int pageSize)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesHistory(userEntity.Id, pageNumber, pageSize)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<MovieRead> GetMoviesSubscription(int pageNumber, int pageSize)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesSubscription(userEntity.Id, pageNumber, pageSize)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }

        public List<MovieRead> GetMoviesCollection(int pageNumber, int pageSize)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.Movies
              .GetMoviesCollection(userEntity.Id, pageNumber, pageSize)
              .Select(movie => MovieReadConverter.ToBLLModel(movie))
              .ToList();
        }
    }
}