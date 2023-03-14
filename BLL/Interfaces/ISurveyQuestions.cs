using Library.Models.SurveyQuestion;

namespace BLL.Interfaces
{
    public interface ISurveyQuestions
    {
        List<SurveyQuestionRead> GetAll();
        SurveyQuestionRead? GetByUid(Guid uid);
        Guid GetGuidBySurveyAnswerGuid(Guid uid);
    }
}