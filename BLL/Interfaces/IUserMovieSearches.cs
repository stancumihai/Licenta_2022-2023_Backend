using Library.Models.UserMovieSearch;

namespace BLL.Interfaces
{
    public interface IUserMovieSearches
    {
        UserMovieSearchCreate Add(UserMovieSearchCreate userMovieSearchCreate);
    }
}