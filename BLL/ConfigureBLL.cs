using BLL.Core;
using BLL.Implementation;
using BLL.Implementation.Mechanisms;
using BLL.Interfaces;
using BLL.Interfaces.Mechanisms;
using DAL.Models;
using Library.Settings;
using Microsoft.AspNetCore.Identity;
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
        var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
        services.AddSingleton(emailConfig);
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();

        return services;
    }
}