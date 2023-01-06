﻿using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class SurveyAnswers : DALObject, ISurveyAnswers
    {
        public SurveyAnswers(DatabaseContext context) : base(context)
        {
        }

        public List<SurveyAnswer> GetAll()
        {
            return _context.SurveyAnswers
                .Include(sa => sa.SurveyQuestion)
                .ToList();
        }

        public SurveyAnswer? GetByUid(Guid uid)
        {
            SurveyAnswer? surveyAnswer = _context.SurveyAnswers
                .Include(sa => sa.SurveyQuestion)
                .FirstOrDefault(sa => sa.SurveyAnswerGUID.Equals(uid));
            if(surveyAnswer == null)
            {
                return null;
            }
            return surveyAnswer;
        }
    }
}