using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.Core;
using DAL.Interfaces;
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
        services.AddScoped<ISurveyUserAnswers, SurveyUserAnswers>();
        services.AddScoped<IMovies, Movies>();
        services.AddScoped<IMovieRatings, MovieRatings>();
        services.AddScoped<IKnownFor, KnownFor>();
        services.AddScoped<IPersons, Persons>();
        services.AddScoped<ILikedMovies, LikedMovies>();
        services.AddScoped<IMovieSubscriptions, MovieSubscriptions>();
        services.AddScoped<ISeenMovies, SeenMovies>();
        services.AddScoped<IUserMovieRatings, UserMovieRatings>();
        services.AddScoped<IUserProfiles, UserProfiles>();
        return services;
    }
}