using Library.Models.Movie;

namespace BLL.Interfaces
{
    public interface IMovies
    {
        MovieCreate Add(MovieCreate surveyAnswer);
        List<MovieRead> GetAll();
        MovieRead? GetByUid(Guid uid);
    }
}