using Library.Models._UI;
using Library.Models.Movie;
using Library.Models.SeenMovie;

namespace BLL.Interfaces
{
    public interface ISeenMovies
    {
        SeenMovieCreate Add(SeenMovieCreate movieSubscription);
        List<SeenMovieRead> GetAll();
        SeenMovieRead? GetByUid(Guid uid);
        SeenMovieRead Delete(Guid uid);
        List<SeenMovieRead> GetByUserAndMovie(Guid movieUid);
        List<MonthlyAppUsageModel> GetMonthlySeenMoviesByUser();
        List<TopGenreModel> GetTopSeenGenresByUser();
        List<MonthlyAppUsageModel> GetMonthlySeenMovies();
        List<TopGenreModel> GetTopSeenGenres();
        List<MovieRead> GetAllByUser(string userGUID);
        List<AgeViewershipModel> GetAgeViewershipByMonth(int year, int month);
        //List<MonthlyAppUsageModel> GetMonthlySeenMoviesRange(DateTime start, DateTime end);
        List<MonthlyAppUsageModel> GetMonthlySeenMoviesRange(int startYear, int endYear, int startMonth, int endMonth);

    }
}