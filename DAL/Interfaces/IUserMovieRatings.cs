using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserMovieRatings
    {
        List<UserMovieRating> GetAll();
        List<UserMovieRating> GeAllByLoggedUser(string userGUID);
        UserMovieRating GetByUid(Guid guid);
        UserMovieRating? Add(UserMovieRating userMovieRating);
        void Delete(Guid guid);
        UserMovieRating? Update(UserMovieRating newUserMovieRating);
    }
}