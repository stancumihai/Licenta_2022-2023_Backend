﻿using BLL.Core;
using BLL.Implementation;
using BLL.Implementation.MachineLearning;
using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Jobs;
using BLL.Interfaces;
using BLL.Interfaces.MachineLearning;
using BLL.Interfaces.Mechanisms;
using DAL.Models;
using Library.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace BLL;
public static class ConfigureBLL
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<BusinessContext>();
        services.AddScoped<IUsers, UsersBL>();
        services.AddScoped<ISurveyAnswers, SurveyAnswersBL>();
        services.AddScoped<ISurveyQuestions, SurveyQuestionsBL>();
        services.AddScoped<ISurveyUserAnswers, SurveyUserAnswersBL>();
        services.AddScoped<IAuthentication, AuthenticationBL>();
        services.AddScoped<IMovies, MoviesBL>();
        services.AddScoped<IMovieRatings, MovieRatingsBL>();
        services.AddScoped<IKnownFor, KnownForBL>();
        services.AddScoped<IPersons, PersonsBL>();
        services.AddScoped<ILikedMovies, LikedMoviesBL>();
        services.AddScoped<IMovieSubscriptions, MovieSubscriptionsBL>();
        services.AddScoped<ISeenMovies, SeenMoviesBL>();
        services.AddScoped<IUserMovieRatings, UserMovieRatingsBL>();
        var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
        services.AddSingleton(emailConfig);
        services.AddScoped<IEmailSender, EmailService>();
        services.AddScoped<IRecommendationManager, RecommendationManager>();
        services.AddScoped<IUserProfiles, UserProfilesBL>();
        services.AddScoped<IRecommendations, RecommendationsBL>();
        services.AddScoped<IAlgorithmChanges, AlgorithmChangesBL>();
        services.AddScoped<IUserMovieSearches, UserMovieSearchesBL>();
        services.AddScoped<IMachineLearningTraining, MachineLearningTrainingBL>();
        services.AddScoped<IPredictedGenres, PredictedGenresBL>();
        services.AddScoped<IPredictedMoviesCount, PredictedMoviesCountBL>();
        services.AddScoped<IPredictedMoviesRuntime, PredictedMoviesRuntimeBL>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();
        services.AddSingleton<Hub, NotificationHub>();
        services.AddHostedService<MovieRecommendationJob>();
        services.AddHostedService<PredictedGenreJob>();
        services.AddHostedService<PredictedMoviesCountJob>();
        services.AddHostedService<PredictedMoviesRuntimeJob>();
        return services;
    }
}