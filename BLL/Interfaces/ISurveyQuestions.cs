using Library.Models.SurveyQuestion;

namespace BLL.Interfaces
{
    public interface ISurveyQuestions
    {
        // Add(SurveyQuestion surveyQuestion);
        List<SurveyQuestionRead> GetAll();
        //void Update(SurveyQuestion surveyQuestion);
        // Delete(Guid uid);
        SurveyQuestionRead? GetByUid(Guid uid);
    }
}