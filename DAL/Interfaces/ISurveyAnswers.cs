using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISurveyAnswers
    {
        SurveyAnswer Add(SurveyAnswer surveyAnswer);
        List<SurveyAnswer> GetAll();
        //void Update(SurveyAnswer surveyAnswer);
        //void Delete(Guid uid);
        SurveyAnswer? GetByUid(Guid uid);
    }
}