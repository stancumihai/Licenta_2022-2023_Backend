
using Library.Models.Movie;
using Library.Models.SurveyUserAnswer;

namespace BLL.Interfaces
{
    public interface IRecommendationManager
    {
        List<MovieRead> GetInitialMovieRecommendations(SurveyUserAnswerCreateBatch surveyUserAnswerCreateBatch);
    }
}