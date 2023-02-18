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

        public SurveyAnswerCreate Add(SurveyAnswerCreate surveyAnswer)
        {
            DAL.Models.SurveyAnswer addedSurveyAnswer = SurveyAnswerCreateConverter.ToDALModel(surveyAnswer);
            return SurveyAnswerCreateConverter.ToBLLModel(_dalContext.SurveyAnswers.Add(addedSurveyAnswer));
        }

        public List<SurveyAnswerRead> GetAll()
        {
            return _dalContext.SurveyAnswers
               .GetAll()
               .Select(surveyAnswer => SurveyAnswerReadConverter.ToBLLModel(surveyAnswer))
               .ToList();
        }

        public List<SurveyAnswerRead> GetAllByQuestionUid(Guid questionUid)
        {
            return _dalContext.SurveyAnswers
                .GetAllByQuestionUid(questionUid)
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