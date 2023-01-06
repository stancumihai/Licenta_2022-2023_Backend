using BLL.Converters.SurveyQuestion;
using BLL.Core;
using BLL.Interfaces;
using Library.Models.SurveyQuestion;

namespace BLL.Implementation
{
    public class SurveyQuestionsBL : BusinessObject, ISurveyQuestions
    {
        public SurveyQuestionsBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }
        public List<SurveyQuestionRead> GetAll()
        {
            return _dalContext.SurveyQuestions
                .GetAll()
                .Select(surveyQuestion => SurveyQuestionReadConverter.ToBLLModel(surveyQuestion))
                .ToList();
        }

        public SurveyQuestionRead? GetByUid(Guid uid)
        {
            return _dalContext.SurveyQuestions
                .GetAll()
                .Select(surveyQuestion => SurveyQuestionReadConverter.ToBLLModel(surveyQuestion))
                .FirstOrDefault(surveyQuestion => surveyQuestion.Uid.Equals(uid));
        }
    }
}