using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISurveyUserAnswers
    {
        SurveyUserAnswer Add(SurveyUserAnswer surveyUserAnswer);
        List<SurveyUserAnswer> GetAll();
        SurveyUserAnswer GetByUid(Guid uid);
        List<SurveyUserAnswer> GetAllByUser(string userUid);
    }
}