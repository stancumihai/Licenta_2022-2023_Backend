using Library.Models;
using Library.Models.SurveyUserAnswer;

namespace BLL.Interfaces
{
    public interface ISurveyUserAnswers
    {
        SurveyUserAnswerCreate Add(SurveyUserAnswerCreate surveyUserAnswer);
        List<SurveyUserAnswerRead> GetAll();
        SurveyUserAnswerRead GetByUid(Guid uid);
    }
}