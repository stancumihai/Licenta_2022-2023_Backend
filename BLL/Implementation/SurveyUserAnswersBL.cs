using BLL.Converters.SurveyUserAnswer;
using BLL.Core;
using DAL.Models;
using Library.Models;
using Library.Models.SurveyUserAnswer;

namespace BLL.Implementation
{
    public class SurveyUserAnswersBL : BusinessObject, Interfaces.ISurveyUserAnswers
    {
        public SurveyUserAnswersBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public SurveyUserAnswerCreate Add(SurveyUserAnswerCreate surveyUserAnswer)
        {
            SurveyUserAnswer addedSurveyUserAnswer = SurveyUserAnswerCreateConverter.ToDALModel(surveyUserAnswer);
            ApplicationUser user = _dalContext.Users.GetByUid(surveyUserAnswer.UserUid)!;
            SurveyQuestion surveyQuestion = _dalContext.SurveyQuestions.GetByUid(surveyUserAnswer.SurveyQuestionUid)!;
            if (user == null || surveyQuestion == null)
            {
                return null;
            }
            if(surveyUserAnswer.SurveyAnswerUid != Guid.Empty)
            {
                SurveyAnswer surveyAnswer = _dalContext.SurveyAnswers.GetByUid(surveyUserAnswer.SurveyAnswerUid)!;
                if(surveyAnswer != null)
                {
                    addedSurveyUserAnswer.Value = surveyAnswer.Value;
                }
            }
            return SurveyUserAnswerCreateConverter.ToBLLModel(_dalContext.SurveyUserAnswers.Add(addedSurveyUserAnswer));
        }

        public List<SurveyUserAnswerRead> GetAll()
        {
            return _dalContext.SurveyUserAnswers
              .GetAll()
              .Select(surveyAnswer => SurveyUserAnswerReadConverter.ToBLLModel(surveyAnswer))
              .ToList();
        }

        public SurveyUserAnswerRead GetByUid(Guid uid)
        {
            return _dalContext.SurveyUserAnswers
               .GetAll()
               .Select(surveyAnswer => SurveyUserAnswerReadConverter.ToBLLModel(surveyAnswer))
               .FirstOrDefault(surveyUserAnswer => surveyUserAnswer.Uid.Equals(uid))!;
        }
    }
}