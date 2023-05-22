using BLL.Interfaces;
using BLL.Interfaces.MachineLearning;
using BLL.Interfaces.Mechanisms;
using Microsoft.AspNetCore.Http;

namespace BLL.Core;
public class BusinessContext
{
    public IUsers? Users { get; set; }
    public ISurveyQuestions? SurveyQuestions { get; set; }
    public ISurveyAnswers? SurveyAnswers { get; set; }
    public ISurveyUserAnswers? SurveyUserAnswers { get; set; }
    public IAuthentication? Authentication { get; set; }
    public IMovies? Movies { get; set; }
    public IMovieRatings? MovieRatings { get; set; }
    public IEmailSender EmailSender { get; set; }
    public IPersons Persons { get; set; }
    public IKnownFor KnownFor { get; set; }
    public ILikedMovies LikedMovies { get; set; }
    public IMovieSubscriptions MovieSubscriptions { get; set; }
    public ISeenMovies SeenMovies { get; set; }
    public IUserMovieRatings UserMovieRatings { get; set; }
    public IRecommendationManager RecommendationManager { get; set; }
    public IUserProfiles UserProfiles { get; set; }
    public IAlgorithmChanges AlgorithmChanges { get; set; }
    public IRecommendations Recommendations { get; set; }
    public IUserMovieSearches UserMovieSearches { get; set; }
    public IMachineLearningTraining MachineLearningTraining { get; set; }
    public IPredictedGenres PredictedGenres { get; set; }
    public IPredictedMoviesCount PredictedMoviesCount { get; set; }
    public IPredictedMoviesRuntime PredictedMoviesRuntime { get; set; }
    public readonly IHttpContextAccessor HttpContextAccessor;

    public BusinessContext(ISurveyQuestions surveyQuestions,
                            ISurveyAnswers surveyAnswers,
                            IAuthentication? authentication,
                            IUsers? users,
                            IEmailSender emailSender,
                            ISurveyUserAnswers? surveyUserAnswers,
                            IMovies? movies,
                            IMovieRatings? movieRatings,
                            IKnownFor knownFor,
                            IPersons persons,
                            ILikedMovies likedMovies,
                            IMovieSubscriptions movieSubscriptions,
                            ISeenMovies seenMovies,
                            IUserMovieRatings userMovieRatings,
                            IHttpContextAccessor httpContextAccessor,
                            IRecommendationManager recommendationManager,
                            IUserProfiles userProfiles,
                            IRecommendations recommendations,
                            IAlgorithmChanges algorithmChanges,
                            IUserMovieSearches userMovieSearches,
                            IMachineLearningTraining machineLearningTraining,
                            IPredictedGenres predictedGenres,
                            IPredictedMoviesCount predictedMoviesCount,
                            IPredictedMoviesRuntime predictedMoviesRuntime)
    {
        SurveyQuestions = surveyQuestions;
        SurveyAnswers = surveyAnswers;
        Authentication = authentication;
        Users = users;
        EmailSender = emailSender;
        SurveyUserAnswers = surveyUserAnswers;
        Movies = movies;
        MovieRatings = movieRatings;
        KnownFor = knownFor;
        Persons = persons;
        LikedMovies = likedMovies;
        MovieSubscriptions = movieSubscriptions;
        SeenMovies = seenMovies;
        UserMovieRatings = userMovieRatings;
        RecommendationManager = recommendationManager;
        UserProfiles = userProfiles;
        Recommendations = recommendations;
        HttpContextAccessor = httpContextAccessor;
        AlgorithmChanges = algorithmChanges;
        UserMovieSearches = userMovieSearches;
        MachineLearningTraining = machineLearningTraining;
        PredictedGenres = predictedGenres;
        PredictedMoviesCount = predictedMoviesCount;
        PredictedMoviesRuntime = predictedMoviesRuntime;
    }
}