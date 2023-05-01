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
        public IPersons Persons { get; }
        public IKnownFor KnownFor { get; }
        public ILikedMovies LikedMovies { get; }
        public IMovieSubscriptions MovieSubscriptions { get; }
        public ISeenMovies SeenMovies { get; }
        public IUserMovieRatings UserMovieRatings { get; }
        public IUserProfiles UserProfiles { get; }
        public DALContext(ISurveyAnswers surveyAnswers,
            ISurveyQuestions surveyQuestions,
            IUsers users,
            ISurveyUserAnswers surveyUserAnswers,
            IMovies movies,
            IMovieRatings movieRatings,
            IPersons persons,
            IKnownFor knownFor,
            ILikedMovies likedMovies,
            IMovieSubscriptions moviesSubscriptions,
            ISeenMovies seenMovies,
            IUserMovieRatings userMovieRatings,
            IUserProfiles userProfiles)
        {
            SurveyAnswers = surveyAnswers;
            SurveyQuestions = surveyQuestions;
            Users = users;
            SurveyUserAnswers = surveyUserAnswers;
            Movies = movies;
            MovieRatings = movieRatings;
            Persons = persons;
            KnownFor = knownFor;
            LikedMovies = likedMovies;
            MovieSubscriptions = moviesSubscriptions;
            SeenMovies = seenMovies;
            UserMovieRatings = userMovieRatings;
            UserProfiles = userProfiles;
        }
    }
}