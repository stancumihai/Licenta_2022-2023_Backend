using DAL.Core;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class SurveyAnswers : DALObject, ISurveyAnswers
    {
        public SurveyAnswers(DatabaseContext context) : base(context)
        {
        }
        public SurveyAnswer Add(SurveyAnswer surveyAnswer)
        {
            SurveyAnswer addedSurveyAnswer = _context.SurveyAnswers.Add(surveyAnswer).Entity;
            _context.SaveChanges();
            return addedSurveyAnswer;
        }

        public List<SurveyAnswer> GetAll()
        {
            return _context.SurveyAnswers
                //.Include(sa => sa.SurveyUserAnswers)
                .ToList();
        }
        public List<SurveyAnswer> GetAllByQuestionUid(Guid questionUid)
        {
            return _context.SurveyAnswers
                //.Include(sa => sa.SurveyUserAnswers)
                .Where(sa => sa.SurveyQuestionGUID == questionUid)
                .ToList();
        }
        public SurveyAnswer? GetByUid(Guid? uid)
        {
            SurveyAnswer? surveyAnswer = _context.SurveyAnswers
                //.Include(sa => sa.SurveyUserAnswers)
                .FirstOrDefault(sa => sa.SurveyAnswerGUID.Equals(uid));
            if (surveyAnswer == null)
            {
                return null;
            }
            return surveyAnswer;
        }
    }
}