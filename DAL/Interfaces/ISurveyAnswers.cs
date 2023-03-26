using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISurveyAnswers
    {
        SurveyAnswer Add(SurveyAnswer surveyAnswer);
        List<SurveyAnswer> GetAll();
        List<SurveyAnswer> GetAllByQuestionUid(Guid questionUid);
        SurveyAnswer? GetByUid(Guid? uid);
    }
}