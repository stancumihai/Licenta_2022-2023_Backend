using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class SurveyUserAnswers : DALObject, ISurveyUserAnswers
    {
        public SurveyUserAnswers(DatabaseContext context) : base(context)
        {
        }

        public SurveyUserAnswer Add(SurveyUserAnswer surveyUserAnswer)
        {
            SurveyUserAnswer addedSurveyUserAnswer = _context.SurveyUserAnswers.Add(surveyUserAnswer).Entity;
            _context.SaveChanges();
            return addedSurveyUserAnswer;
        }

        public List<SurveyUserAnswer> GetAllByUser(string userUid)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(u => u.Id == userUid);
            if (user == null)
            {
                return null;
            }
            return _context.SurveyUserAnswers.
                Where(sua => sua.UserGUID == userUid)
               .Include(sua => sua.SurveyQuestion)
               .ToList();
        }

        public List<SurveyUserAnswer> GetAll()
        {
            return _context.SurveyUserAnswers
                .Include(sua => sua.SurveyQuestion)
                .ToList();
        }

        public SurveyUserAnswer GetByUid(Guid uid)
        {
            return _context.SurveyUserAnswers
                .Include(sua => sua.SurveyQuestion)
                .FirstOrDefault(sua => sua.SurveyUserAnswerGUID == uid)!;
        }
    }
}