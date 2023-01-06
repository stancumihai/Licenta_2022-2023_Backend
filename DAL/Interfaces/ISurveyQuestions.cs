using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISurveyQuestions
    {
        //SurveyQuestion Add(SurveyQuestion surveyQuestion);
        List<SurveyQuestion> GetAll();
        //void Update(SurveyQuestion surveyQuestion);
        //void Delete(Guid uid);
        SurveyQuestion? GetByUid(Guid uid);
    }
}