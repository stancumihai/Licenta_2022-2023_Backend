using BLL.Core;
using BLL.Implementation;
using BLL.Implementation.Mechanisms;
using BLL.Interfaces;
using BLL.Interfaces.Mechanisms;
using Library.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;
public static class ConfigureBLL
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<BusinessContext>();
        services.AddScoped<IUsers, UsersBL>();
        services.AddScoped<ISurveyAnswers, SurveyAnswersBL>();
        services.AddScoped<ISurveyQuestions, SurveyQuestionsBL>();
        var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
        services.AddSingleton(emailConfig);
        services.AddScoped<IEmailSender, EmailSender>();
        return services;
    }
}