using DAL.Interfaces;

namespace DAL
{
    public class DALContext: IDALContext
    {
        public IUsers Users { get; }
        public ISurveyAnswers SurveyAnswers { get; }
        public ISurveyQuestions SurveyQuestions { get; }

        public DALContext(IUsers users, ISurveyAnswers surveyAnswers, ISurveyQuestions surveyQuestions)
        {
            Users = users;
            SurveyAnswers = surveyAnswers;
            SurveyQuestions = surveyQuestions;
        }
    }
}