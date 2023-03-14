using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class SurveyQuestions : DALObject, ISurveyQuestions
    {
        public SurveyQuestions(DatabaseContext context) : base(context)
        {
        }

        public List<SurveyQuestion> GetAll()
        {
            return _context.SurveyQuestions
                .Include(sq => sq.SurveyAnswers)
                .ToList();
        }

        public SurveyQuestion? GetByUid(Guid uid)
        {
            SurveyQuestion? surveyQuestion = _context.SurveyQuestions
                .Include(sq => sq.SurveyAnswers)
                .FirstOrDefault(sq => sq.SurveyQuestionGUID.Equals(uid));
            if (surveyQuestion == null)
            {
                return null;
            }
            return surveyQuestion;
        }
        public Guid GetGuidBySurveyAnswerGuid(Guid surveyAnswerGuid)
        {
            return _context.SurveyAnswers
                .FirstOrDefault(surveyQuestion => surveyQuestion.SurveyAnswerGUID.Equals(surveyAnswerGuid))!.SurveyQuestionGUID;
        }
    }
}