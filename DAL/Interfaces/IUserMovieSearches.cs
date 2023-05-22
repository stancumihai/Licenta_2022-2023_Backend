using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserMovieSearches
    {
        UserMovieSearch? Add(UserMovieSearch userMovieSearch);
        List<UserMovieSearch> GetAll();
    }
}