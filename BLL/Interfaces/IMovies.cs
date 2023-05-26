using Library.Models._UI;
using Library.Models.Movie;

namespace BLL.Interfaces
{
    public interface IMovies
    {
        MovieCreate Add(MovieCreate movie);
        List<MovieRead> GetAll();
        MovieRead? GetByUid(Guid uid);
        MovieRead? GetByMovieId(string movieId);
        List<MovieRead> GetPaginatedMovies(int pageNumber, int pageSize);
        List<MovieRead> GetAllByPersonUid(Guid personGuid);
        List<MovieRead> GetMoviesByGenrePaginated(string genre, int pageNumber, int pageSize);
        List<string> GetMovieGenres();
        List<MovieRead> GetMoviesHistoryPaginated(int pageNumber, int pageSize);
        List<MovieRead> GetMoviesSubscriptionPaginated(int pageNumber, int pageSize);
        List<MovieRead> GetMoviesCollectionPaginated(int pageNumber, int pageSize);
        List<MovieRead> GetMoviesHistory();
        List<MovieRead> GetMoviesSubscription();
        List<MovieRead> GetMoviesCollection();
        List<string> GetTopLikedGenres();
        List<MovieRead> GetAdvancedSearchMovies(SearchModel searcModel);
        List<MovieRead> GetAllMoviesCollectionByUser(string userUid);
    }
}