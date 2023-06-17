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
using Serilog;
using Services.Filters;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Services.BuildServiceProvider()
    .GetRequiredService<IConfiguration>();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File($"Logs/{String.Format("{0}", DateTime.Now.ToString("dd_MM_yyyy"))}.log")
    .CreateLogger();

builder.Services.AddSignalR();
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

#region Controllers BadRequestObjectResult
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
#endregion

#region Controllers HttpResponseExceptionFilter
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
    IMovies moviesBL = (MoviesBL)scope.ServiceProvider.GetService(typeof(IMovies))!;
    IMovieRatings movieRatingsBL = (MovieRatingsBL)scope.ServiceProvider.GetService(typeof(IMovieRatings))!;

    Tuple<List<Movie>, List<Library.Models.Excel.MovieRating>> movieInformations = CSVReaderService.GetMovieInformation();
    bool hasMovies = moviesBL.GetAll().Count != 0;
    bool hasMovieRatings = moviesBL.GetAll().Count != 0;
    if (!hasMovies)
    {
        foreach (Movie movie in movieInformations.Item1)
        {
            moviesBL.Add(MovieCreateConverter.ToBLLModel(movie));
        }
    }
}

void CreateMovieRatings(IServiceProvider serviceProvider)
{
    using var scope = app.Services.CreateScope();
    IMovies moviesBL = (MoviesBL)scope.ServiceProvider.GetService(typeof(IMovies))!;
    IMovieRatings movieRatingsBL = (MovieRatingsBL)scope.ServiceProvider.GetService(typeof(IMovieRatings))!;

    Tuple<List<Movie>, List<Library.Models.Excel.MovieRating>> movieInformations = CSVReaderService.GetMovieInformation();
    bool hasMovieRatings = movieRatingsBL.GetAll().Count != 0;
    if (!hasMovieRatings)
    {
        foreach (Library.Models.Excel.MovieRating movieExcelEntity in movieInformations.Item2)
        {
            Movie movie = MovieReadConverter.ToDALModel(moviesBL.GetByMovieId(movieExcelEntity.MovieId)!);
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
    using var scope = app!.Services.CreateScope();
    IMovies movieBL = (MoviesBL)scope.ServiceProvider.GetService(typeof(IMovies))!;
    IKnownFor knownForBL = (KnownForBL)scope.ServiceProvider.GetService(typeof(IKnownFor))!;
    IPersons personsBL = (PersonsBL)scope.ServiceProvider.GetService(typeof(IPersons))!;
    List<Library.Models.Excel.Person> persons = CSVReaderService.GetPersons();
    bool hasData = personsBL.GetAll().Count != 0;
    if (!hasData)
    {
        foreach (Library.Models.Excel.Person personEntity in persons)
        {
            List<string> personExcelMoviesIds = personEntity.Movies;
            List<Movie> personFoundMovies = new();
            foreach (string personMovieId in personExcelMoviesIds)
            {
                MovieRead currentMovie = movieBL.GetByMovieId(personMovieId)!;
                if (currentMovie != null)
                {
                    personFoundMovies.Add(MovieReadConverter.ToDALModel(currentMovie));
                }
            }
            if (personFoundMovies.Count != 0)
            {
                Person person = new()
                {
                    PersonGUID = personEntity.PersonGUID,
                    Name = personEntity.Name,
                    YearOfBirth = personEntity.YearOfBirth,
                    YearOfDeath = personEntity.YearOfDeath,
                    Professions = personEntity.Professions,
                };
                try
                {
                    Person addedPerson = PersonReadConverter.ToDALModel(personsBL.Add(PersonCreateConverter.ToBLLModel(person)));
                    foreach (Movie currentMovie in personFoundMovies)
                    {
                        try
                        {
                            KnownFor knownFor = new()
                            {
                                MovieGUID = currentMovie.MovieGUID,
                                PersonGUID = addedPerson.PersonGUID
                            };
                            knownForBL.Add(KnownForCreateConverter.ToBLLModel(knownFor));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}

async Task CreateUsers(IServiceProvider serviceProvider)
{
    using var scope = app!.Services.CreateScope();
    DAL.Interfaces.IUserSeeder userSeeder = (DAL.Seeders.UserSeeder)scope.ServiceProvider.GetService(typeof(DAL.Interfaces.IUserSeeder))!;
    await userSeeder.SeedUsers();
}

async Task AddAdditionalDataToUsers(IServiceProvider serviceProvider)
{
    using var scope = app!.Services.CreateScope();
    DAL.Interfaces.IUserSeeder userSeeder = (DAL.Seeders.UserSeeder)scope.ServiceProvider.GetService(typeof(DAL.Interfaces.IUserSeeder))!;
    await userSeeder.SeedAdditionalData(2023, 7);
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notification");
});
app.UseWebSockets();
//await CreateUsers(app.Services);
//CreateRoles(app.Services).Wait();
//CreateMovies(app.Services);
//CreateMovieRatings(app.Services);
//CreatePersons(app.Services);
//await AddAdditionalDataToUsers(app.Services);
app.Run();