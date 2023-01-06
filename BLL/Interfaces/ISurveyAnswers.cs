using Library.Models.SurveyAnswer;

namespace BLL.Interfaces
{
    public interface ISurveyAnswers
    {
        SurveyAnswerCreate Add(SurveyAnswerCreate surveyAnswer);
        List<SurveyAnswerRead> GetAll();
        //void Update(SurveyAnswer surveyAnswer);
        //void Delete(Guid uid);
        SurveyAnswerRead? GetByUid(Guid uid);
    }
}