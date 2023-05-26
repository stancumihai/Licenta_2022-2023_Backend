using BLL.Converters.Movie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Library.Enums;
using Library.Models._UI;
using Library.Models.Movie;
using Library.Models.SurveyUserAnswer;

namespace BLL.Implementation
{
    internal class RecommendationManager : BusinessObject, IRecommendationManager
    {
        public static readonly string HOW_FREQUENTLY_QUESTION_IDENTIFIER = "How frequently";
        public static readonly string GENRES_QUESTION_IDENTIFIER = "top 3";
        public static readonly int MULTIPLY_MOVIE_RECOMMENDATIONS_CONSTANT = 3;
        public static readonly int MAX_RECOMMENDATION_COUNT = 3;


        public RecommendationManager(IDALContext dalContext) : base(dalContext)
        {
        }

        private List<string> GetQuestionValueByIdentifier(SurveyUserAnswerCreateBatch surveyUserAnswerCreateBatch, string identifier)
        {
            List<string> surveyQuestionValues = new();
            foreach (SurveyUserAnswerCreate surveyUserAnswer in surveyUserAnswerCreateBatch.surveyUserAnswers)
            {
                SurveyQuestion? surveyQuestion = _dalContext.SurveyQuestions.GetByUid(surveyUserAnswer.SurveyQuestionUid);
                if (surveyQuestion == null)
                {
                    return null;
                }
                if (surveyUserAnswer.Value!.Contains(identifier))
                {
                    surveyQuestionValues.Add(surveyQuestion.Value!);
                }
            }
            return surveyQuestionValues;
        }

        private static int MapMovieRecommendationsCount(SurveyUserAnswerCreate surveyUserAnswer)
        {
            int movieRecommendationsCount;
            switch (surveyUserAnswer.Value)
            {
                case "Not at all often":
                    {
                        movieRecommendationsCount = 1;
                        break;
                    }
                case "Moderately often":
                    {
                        movieRecommendationsCount = 2;
                        break;
                    }
                case "Slightly often":
                    {
                        movieRecommendationsCount = 3;
                        break;
                    }
                case "Very often":
                    {
                        movieRecommendationsCount = 4;
                        break;
                    }

                default:
                    {
                        movieRecommendationsCount = 5;
                        break;
                    }
            }
            return movieRecommendationsCount * MULTIPLY_MOVIE_RECOMMENDATIONS_CONSTANT;
        }

        private int GetMovieRecommendationsCount(SurveyUserAnswerCreate surveyUserAnswer)
        {
            SurveyQuestion? surveyQuestion = _dalContext.SurveyQuestions.GetByUid(surveyUserAnswer.SurveyQuestionUid);
            if (surveyQuestion == null)
            {
                return -1;
            }
            if (surveyQuestion.Value!.Contains(HOW_FREQUENTLY_QUESTION_IDENTIFIER))
            {
                return MapMovieRecommendationsCount(surveyUserAnswer);
            }
            return MAX_RECOMMENDATION_COUNT;
        }

        public MovieRecommendationHelperModel BuildInitialRecommendationModel(SurveyUserAnswerCreateBatch surveyUserAnswerCreateBatch)
        {
            string actorName = "";
            string directorName = "";
            string movieName = "";
            foreach (SurveyUserAnswerCreate surveyUserAnswer in surveyUserAnswerCreateBatch.surveyUserAnswers)
            {
                SurveyQuestion? surveyQuestion = _dalContext.SurveyQuestions.GetByUid(surveyUserAnswer.SurveyQuestionUid);
                if (surveyQuestion == null)
                {
                    return null;
                }
                if (surveyQuestion.Value!.Contains(HOW_FREQUENTLY_QUESTION_IDENTIFIER)) continue;

                switch (surveyQuestion.Category)
                {
                    case (DAL.Enums.SurveyQuestionCategory)SurveyQuestionCategory.Actor:
                        {
                            actorName = surveyUserAnswer.Value;
                            break;
                        }
                    case (DAL.Enums.SurveyQuestionCategory)SurveyQuestionCategory.Director:
                        {
                            directorName = surveyUserAnswer.Value;
                            break;
                        }
                    case (DAL.Enums.SurveyQuestionCategory)SurveyQuestionCategory.Movie:
                        {
                            movieName = surveyUserAnswer.Value;
                            break;
                        }
                    default: break;
                }
            }
            return new MovieRecommendationHelperModel()
            {
                ActorName = actorName,
                DirectorName = directorName,
                MovieName = movieName
            };
        }


        public List<MovieRead> GetInitialMovieRecommendations(SurveyUserAnswerCreateBatch surveyUserAnswerCreateBatch)
        {
            List<MovieRead> recommendations = new();
            int movieRecommendationsCount = 0;
            foreach (SurveyUserAnswerCreate surveyUserAnswer in surveyUserAnswerCreateBatch.surveyUserAnswers)
            {
                movieRecommendationsCount = GetMovieRecommendationsCount(surveyUserAnswer);
                if (movieRecommendationsCount != -1)
                {
                    break;
                }
            }
            if (movieRecommendationsCount == -1)
            {
                movieRecommendationsCount = 3;
            }
            MovieRecommendationHelperModel model = BuildInitialRecommendationModel(surveyUserAnswerCreateBatch);
            List<string> surveyQuestionPreferredGenres = GetQuestionValueByIdentifier(surveyUserAnswerCreateBatch, GENRES_QUESTION_IDENTIFIER);
            foreach (Movie movie in _dalContext.Movies.GetAll())
            {
                if (recommendations.Count == movieRecommendationsCount)
                {
                    break;
                }
                if (movie.Title == model.MovieName)
                {
                    recommendations.Add(MovieReadConverter.ToBLLModel(movie));
                    continue;
                }
                string[] movieGenres = movie.Genres.Split(',');
                bool containsGenre = false;
                bool containsPerson = false;
                foreach (string movieGenre in movieGenres)
                {
                    if (surveyQuestionPreferredGenres.Contains(movieGenre))
                    {
                        containsGenre = true;
                        break;
                    }
                }
                List<string> persons = _dalContext.Persons.GetAllByMovieUid(movie.MovieGUID).Select(p => p.Name).ToList();
                if (persons.Contains(model.ActorName) || persons.Contains(model.DirectorName))
                {
                    containsPerson = true;
                }
                if (containsPerson || containsGenre)
                {
                    recommendations.Add(MovieReadConverter.ToBLLModel(movie));
                }

            }
            return recommendations;
        }
    }
}