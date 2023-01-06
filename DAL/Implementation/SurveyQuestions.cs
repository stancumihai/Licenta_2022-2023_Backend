using DAL.Core;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class SurveyQuestions : DALObject, ISurveyQuestions
    {
        public SurveyQuestions(DatabaseContext context) : base(context)
        {
        }

        public List<SurveyQuestion> GetAll()
        {
            return _context.SurveyQuestions.ToList();
        }

        public SurveyQuestion? GetByUid(Guid uid)
        {
            SurveyQuestion? surveyQuestion = _context.SurveyQuestions
                                                .FirstOrDefault(sq => sq.SurveyQuestionGUID.Equals(uid));
            if(surveyQuestion == null)
            {
                return null;
            }
            return surveyQuestion;
        }
    }
}