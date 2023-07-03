using BLL.Converters.Movie;
using BLL.Converters.MovieSubscription;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.Movie;
using Library.Models.MovieSubscription;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class MovieSubscriptionsBL : BusinessObject, IMovieSubscriptions
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieSubscriptionsBL(DAL.Interfaces.IDALContext dalContext,
            IHttpContextAccessor httpContextAccessor) : base(dalContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public MovieSubscriptionCreate Add(MovieSubscriptionCreate movieSubscription)
        {
            MovieSubscription? existingMovieSubscription = _dalContext.MovieSubscriptions.GetAll().FirstOrDefault(m => m.MovieGUID == movieSubscription.MovieUid && m.UserGUID == movieSubscription.UserUid);
            if (existingMovieSubscription != null)
            {
                return null;
            }
            MovieSubscription addedMovieSubscription = MovieSubscriptionCreateConverter.ToDALModel(movieSubscription);
            if (addedMovieSubscription == null)
            {
                return null;
            }
            return MovieSubscriptionCreateConverter.ToBLLModel(_dalContext.MovieSubscriptions.Add(addedMovieSubscription));
        }

        public MovieSubscriptionRead Delete(Guid uid)
        {
            MovieSubscription deletedMovieSubscription = _dalContext.MovieSubscriptions.Delete(uid);
            if (deletedMovieSubscription == null)
            {
                return null;
            }
            return MovieSubscriptionReadConverter.ToBLLModel(deletedMovieSubscription);
        }

        public List<MovieSubscriptionRead> GetAll()
        {
            return _dalContext.MovieSubscriptions
                .GetAll()
                .Select(movieSubscription => MovieSubscriptionReadConverter.ToBLLModel(movieSubscription))
                .ToList();
        }

        public MovieSubscriptionRead? GetByUid(Guid uid)
        {
            MovieSubscription? movieSubscription = _dalContext.MovieSubscriptions.GetByUid(uid);
            if (movieSubscription == null)
            {
                return null;
            }
            return MovieSubscriptionReadConverter
                    .ToBLLModel(movieSubscription);
        }

        public List<MovieRead> GetAllByUser(string userUid)
        {
            List<MovieSubscription> movieSubscriptions = _dalContext
                .MovieSubscriptions
                .GetAllByUser(userUid);

            return movieSubscriptions
                .Select(movieSubscription => MovieReadConverter.ToBLLModel(movieSubscription.Movie))
                .ToList();
        }

        public MovieSubscriptionRead GetByUserAndMovie(Guid movieUid)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            MovieSubscription movieSubscription = _dalContext
                .MovieSubscriptions
                .GetByUserAndMovie(movieUid, userEntity.Id);
            if (movieSubscription == null)
            {
                return null;
            }
            MovieSubscriptionRead movieSubscriptionRead = MovieSubscriptionReadConverter.ToBLLModel(movieSubscription);
            return movieSubscriptionRead;
        }
    }
}