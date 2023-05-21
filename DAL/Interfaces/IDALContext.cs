namespace DAL.Interfaces
{
    public interface IDALContext
    {
        IUsers Users { get; }
        ISurveyAnswers SurveyAnswers { get; }
        ISurveyQuestions SurveyQuestions { get; }
        ISurveyUserAnswers SurveyUserAnswers { get; }
        IMovies Movies { get; }
        IMovieRatings MovieRatings { get; }
        IPersons Persons { get; }
        IKnownFor KnownFor { get; }
        ILikedMovies LikedMovies { get; }
        IMovieSubscriptions MovieSubscriptions { get; }
        ISeenMovies SeenMovies { get; }
        IUserMovieRatings UserMovieRatings { get; }
        IUserProfiles UserProfiles { get; }
        IRecommendations Recommendations { get; }
        IAlgorithmChanges AlgorithmChanges { get; }
        IUserMovieSearches UserMovieSearches { get; }
    }
}