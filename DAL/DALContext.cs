using DAL.Interfaces;

namespace DAL
{
    public class DALContext : IDALContext
    {
        public IUsers Users { get; }
        public ISurveyAnswers SurveyAnswers { get; }
        public ISurveyQuestions SurveyQuestions { get; }
        public ISurveyUserAnswers SurveyUserAnswers { get; }
        public IMovies Movies { get; }
        public IMovieRatings MovieRatings { get; }

        public DALContext(ISurveyAnswers surveyAnswers,
            ISurveyQuestions surveyQuestions,
            IUsers users,
            ISurveyUserAnswers surveyUserAnswers,
            IMovies movies,
            IMovieRatings movieRatings)
        {
            SurveyAnswers = surveyAnswers;
            SurveyQuestions = surveyQuestions;
            Users = users;
            SurveyUserAnswers = surveyUserAnswers;
            Movies = movies;
            MovieRatings = movieRatings;
        }
    }
}