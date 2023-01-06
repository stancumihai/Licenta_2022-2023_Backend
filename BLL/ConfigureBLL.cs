using BLL.Core;
using BLL.Implementation;
using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Optimum.BLL;
public static class ConfigureBLL
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<BusinessContext>();
        services.AddScoped<IUsers, UsersBL>();
        services.AddScoped<ISurveyAnswers, SurveyAnswersBL>();
        services.AddScoped<ISurveyQuestions, SurveyQuestionsBL>();

        return services;
    }
}