using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.Core;
using DAL.Interfaces;
using DAL;
using DAL.Implementation;

namespace DAL;
public static class ConfigureDAL
{
    public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(
                b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));
        });

        services.AddScoped<DatabaseContext>();
        services.AddScoped<IDALContext, DALContext>();
        services.AddScoped<IUsers, Users>();
        services.AddScoped<ISurveyAnswers, SurveyAnswers>();
        services.AddScoped<ISurveyQuestions, SurveyQuestions>();
        return services;
    }
}