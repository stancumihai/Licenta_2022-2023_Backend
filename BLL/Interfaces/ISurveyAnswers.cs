using Library.Models.SurveyAnswer;

namespace BLL.Interfaces
{
    public interface ISurveyAnswers
    {
        //SurveyAnswer Add(SurveyAnswer surveyAnswer);
        List<SurveyAnswerRead> GetAll();
        //void Update(SurveyAnswer surveyAnswer);
        //void Delete(Guid uid);
        SurveyAnswerRead? GetByUid(Guid uid);
    }
}