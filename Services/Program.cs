using BLL;
using BLL.Converters.KnownFor;
using BLL.Converters.Movie;
using BLL.Converters.MovieRating;
using BLL.Converters.Person;
using BLL.Implementation;
using BLL.Implementation.Mechanisms;
using BLL.Interfaces;
using DAL;
using DAL.Core;
using DAL.Models;
using Library.Enums;
using Library.Models.Movie;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Filters;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Services.BuildServiceProvider()
    .GetRequiredService<IConfiguration>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDALServices(builder.Configuration);
builder.Services.AddBLLServices(builder.Configuration);

#region IdentityConfiguration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
}) 
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();
#endregion

#region AuthenticationConfiguration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
    };
});
#endregion

#region Cors Origin Request Service
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                }));
#endregion

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(context.ModelState)
            {
                ContentTypes =
                {
                    Application.Json,
                    Application.Xml
                }
            };
    })
    .AddXmlSerializerFormatters();

#region
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

async Task CreateRoles(IServiceProvider serviceProvider)
{
    using var scope = app.Services.CreateScope();
    var RoleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>))!;
    if (!RoleManager.RoleExistsAsync(UserRoles.Member).Result)
    {
        await RoleManager.CreateAsync(new IdentityRole(UserRoles.Member));
    }

    if (!RoleManager.RoleExistsAsync(UserRoles.Administrator).Result)
    {
        await RoleManager.CreateAsync(new IdentityRole(UserRoles.Administrator));
    }
}

void CreateMovies(IServiceProvider serviceProvider)
{
    using var scope = app.Services.CreateScope();
    IMovies movieBL = (MoviesBL)scope.ServiceProvider.GetService(typeof(IMovies))!;
    List<Movie> movies = CSVReader.GetMovies();
    bool hasData = movieBL.GetAll().Count != 0;
    if (!hasData)
    {
        foreach (Movie movie in movies)
        {
            movieBL.Add(MovieCreateConverter.ToBLLModel(movie));
        }
    }
}

void CreateRatings(IServiceProvider serviceProvider)
{
    using var scope = app.Services.CreateScope();
    IMovieRatings movieRatingsBL = (MovieRatingsBL)scope.ServiceProvider.GetService<IMovieRatings>()!;
    IMovies movieBL = (MoviesBL)scope.ServiceProvider.GetService(typeof(IMovies))!;
    List<Library.Models.Excel.MovieRating> movieRatings = CSVReader.GetMovieRatings();
    List<MovieRead> movies = movieBL.GetAll();
    bool hasData = movieRatingsBL.GetAll().Count != 0;
    if (!hasData)
    {
        foreach (Library.Models.Excel.MovieRating movieExcelEntity in movieRatings)
        {
            Movie movie = MovieReadConverter.ToDALModel(movieBL.GetByMovieId(movieExcelEntity.MovieId)!);
            MovieRating movieRating = new()
            {
                MovieRatingGUID = movieExcelEntity.MovieRatingGUID,
                MovieGUID = movie.MovieGUID,
                AverageRating = movieExcelEntity.AverageRating,
                VotesNumber = movieExcelEntity.VotesNumber
            };
            movieRatingsBL.Add(MovieRatingCreateConverter.ToBLLModel(movieRating));
        }
    }
}

void CreatePersons(IServiceProvider serviceProvider)
{
    using var scope = app.Services.CreateScope();
    IMovies movieBL = (MoviesBL)scope.ServiceProvider.GetService(typeof(IMovies))!;
    IKnownFor knownForBL = (KnownForBL)scope.ServiceProvider.GetService(typeof(IKnownFor))!;
    IPersons personsBL = (PersonsBL)scope.ServiceProvider.GetService(typeof(IPersons))!;
    List<Library.Models.Excel.Person> persons = CSVReader.GetPersons();
    bool hasData = personsBL.GetAll().Count != 0;
    if (!hasData)
    {
        foreach (Library.Models.Excel.Person personEntity in persons)
        {
            Person person = new()
            {
                PersonGUID = personEntity.PersonGUID,
                Name = personEntity.Name,
                YearOfBirth = personEntity.YearOfBirth,
                YearOfDeath = personEntity.YearOfDeath,
                Profession = personEntity.Profession,
            };
            Person addedPerson = PersonReadConverter.ToDALModel(personsBL.Add(PersonCreateConverter.ToBLLModel(person)));
            foreach (string movieId in personEntity.Movies)
            {
                Movie currentMovie = MovieReadConverter.ToDALModel(movieBL.GetByMovieId(movieId)!);
                KnownFor knownFor = new()
                {
                    MovieGUID = currentMovie.MovieGUID,
                    PersonGUID = addedPerson.PersonGUID
                };
                knownForBL.Add(KnownForCreateConverter.ToBLLModel(knownFor));
            }
        }
    }
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

CreateRoles(app.Services).Wait();
CreateMovies(app.Services);
CreateRatings(app.Services);
CreatePersons(app.Services);

app.Run();