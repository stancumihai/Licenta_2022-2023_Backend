using BLL.Core;
using BLL.Implementation;
using BLL.Implementation.Mechanisms;
using BLL.Interfaces;
using BLL.Interfaces.Mechanisms;
using DAL.Models;
using Library.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IRecommendationManager, RecommendationManager>();
        services.AddScoped<IUserProfiles, UserProfilesBL>();
        services.AddScoped<IRecommendations, RecommendationsBL>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();
        services.AddSingleton<Hub, NotificationHub>();
        services.AddHostedService<TimedHostedService>();

        return services;
    }
}