using Library.Models.SurveyAnswer;

namespace BLL.Interfaces
{
    public interface ISurveyAnswers
    {
        SurveyAnswerCreate Add(SurveyAnswerCreate surveyAnswer);
        List<SurveyAnswerRead> GetAll();
        List<SurveyAnswerRead> GetAllByQuestionUid(Guid uid);
        SurveyAnswerRead? GetByUid(Guid uid);
    }
}