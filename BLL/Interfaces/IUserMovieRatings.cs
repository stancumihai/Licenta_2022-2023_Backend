using Library.Models.UserMovieRatings;

namespace BLL.Interfaces
{
    public interface IUserMovieRatings
    {
        List<UserMovieRatingRead> GetAll();
        List<UserMovieRatingRead> GeAllByLoggedUser();
        UserMovieRatingRead GetByUid(Guid guid);
        UserMovieRatingCreate? Add(UserMovieRatingCreate userMovieRating);
        void Delete(Guid guid);
        UserMovieRatingRead? Update(UserMovieRatingRead newUserMovieRating);
    }
}