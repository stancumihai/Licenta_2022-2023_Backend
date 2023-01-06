using BLL.Converters.SurveyAnswer;
using BLL.Core;
using BLL.Interfaces;
using Library.Models.SurveyAnswer;

namespace BLL.Implementation
{
    public class SurveyAnswersBL : BusinessObject, ISurveyAnswers
    {
        public SurveyAnswersBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public List<SurveyAnswerRead> GetAll()
        {
            return _dalContext.SurveyAnswers
               .GetAll()
               .Select(surveyAnswer => SurveyAnswerReadConverter.ToBLLModel(surveyAnswer))
               .ToList();
        }

        public SurveyAnswerRead? GetByUid(Guid uid)
        {
            return _dalContext.SurveyAnswers
               .GetAll()
               .Select(surveyAnswer => SurveyAnswerReadConverter.ToBLLModel(surveyAnswer))
               .FirstOrDefault(surveyAnswer => surveyAnswer.Uid.Equals(uid));
        }
    }
}