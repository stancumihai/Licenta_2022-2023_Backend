using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISurveyQuestions
    {
        List<SurveyQuestion> GetAll();
        SurveyQuestion? GetByUid(Guid uid);
        Guid GetGuidBySurveyAnswerGuid(Guid uid);
    }
}