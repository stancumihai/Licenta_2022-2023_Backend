using BLL.Converters.MovieRating;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.MovieRating;

namespace BLL.Implementation
{
    public class MovieRatingsBL : BusinessObject, IMovieRatings
    {
        public MovieRatingsBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public void Add(MovieRatingCreate movieRating)
        {
            MovieRating addedMovieRating = MovieRatingCreateConverter.ToDALModel(movieRating);
            MovieRatingCreateConverter.ToBLLModel(_dalContext.MovieRatings.Add(addedMovieRating));
        }

        public List<MovieRatingRead> GetAll()
        {
            return _dalContext.MovieRatings
               .GetAll()
               .Select(movieRating => MovieRatingReadConverter.ToBLLModel(movieRating))
               .ToList();
        }

        public MovieRatingRead? GetByMovieUid(Guid movieUid)
        {
            return MovieRatingReadConverter.ToBLLModel(_dalContext.MovieRatings
               .GetByMovieUid(movieUid)!);
        }

        public MovieRatingRead? GetByUid(Guid uid)
        {
            return MovieRatingReadConverter.ToBLLModel(_dalContext.MovieRatings
               .GetByUid(uid)!);
        }

        public MovieRatingRead? Update(MovieRatingRead movieRatingRead)
        {
            MovieRating? newMovieRating = _dalContext.MovieRatings.Update(MovieRatingReadConverter.ToDALModel(movieRatingRead));
            if(newMovieRating == null)
            {
                return null;
            }
            return MovieRatingReadConverter.ToBLLModel(newMovieRating);
        }
    }
}