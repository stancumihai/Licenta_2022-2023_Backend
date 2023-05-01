using BLL.Converters.SurveyUserAnswer;
using BLL.Core;
using DAL.Models;
using Library.Models;
using Library.Models.SurveyUserAnswer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class SurveyUserAnswersBL : BusinessObject, Interfaces.ISurveyUserAnswers
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SurveyUserAnswersBL(DAL.Interfaces.IDALContext dalContext,
            IHttpContextAccessor httpContextAccessor) : base(dalContext)
        {
            _httpContextAccessor = httpContextAccessor;
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
            if (surveyUserAnswer.SurveyAnswerUid != Guid.Empty)
            {
                SurveyAnswer surveyAnswer = _dalContext.SurveyAnswers.GetByUid(surveyUserAnswer.SurveyAnswerUid)!;
                if (surveyAnswer != null)
                {
                    addedSurveyUserAnswer.Value = surveyAnswer.Value;
                }
                return SurveyUserAnswerCreateConverter.ToBLLModel(_dalContext.SurveyUserAnswers.Add(addedSurveyUserAnswer));
            }
            addedSurveyUserAnswer.SurveyAnswer = null;
            addedSurveyUserAnswer.SurveyAnswerGUID = null;

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
        public List<SurveyUserAnswerRead> GetAllByUser()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            List<SurveyUserAnswer> surveyUserAnswers = _dalContext.SurveyUserAnswers.GetAllByUser(userEntity.Id);
            if (surveyUserAnswers == null)
            {
                return null;
            }
            return surveyUserAnswers.Select(surveyAnswer => SurveyUserAnswerReadConverter.ToBLLModel(surveyAnswer))
                .ToList();
        }

        public int AddInSuperBatches(SurveyUserAnswerCreateBatch surveyUserAnswerCreateBatch)
        {
            foreach (SurveyUserAnswerCreate surveyUserAnswer in surveyUserAnswerCreateBatch.surveyUserAnswers)
            {
                var response = Add(surveyUserAnswer);
                if (response == null)
                {
                    return -1;
                }
            }

            return 1;
        }
    }
}