using DAL.Enums;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        private static readonly string ConnectionString = "Database=Licenta;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyUserAnswer> SurveyUserAnswers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<KnownFor> KnownFor { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<LikedMovie> LikedMovies { get; set; }
        public DbSet<MovieSubscription> MovieSubscriptions { get; set; }
        public DbSet<SeenMovie> SeenMovies { get; set; }
        public DbSet<UserMovieRating> UserMovieRatings { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
           => dbContext.UseSqlServer(ConnectionString);

        private static readonly IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
        {
            {"1.How frequently do you watch movies?",
                new List<string>(){
                    "Extremely often",
                    "Very often",
                    "Moderately often",
                    "Slightly often",
                    "Not at all often"
                }
            },
            {"2.Out of all the movies you have ever seen, which is your most favourite?Movie",new List<string>() },
            {"3.Who is your favourite actor?Actor",new List<string>() },
            {"4.Who is your favourite director?Director",new List<string>() },
            {"5.What are your top 3 favourite kind of genres?",
                new List<string>() {
                               "Horror",
                               "Romance",
                               "Action/Adventure",
                               "Thriller",
                               "Science-Fiction",
                                "Comedy",
                                "Drama",
                                "Musical"
                }
            }
        };

        private static SurveyQuestionCategory StringToCategory(string category)
        {
            switch (category)
            {
                case "Movie": return SurveyQuestionCategory.Movie;
                case "Actor": return SurveyQuestionCategory.Actor;
                case "Director": return SurveyQuestionCategory.Director;
                default: return SurveyQuestionCategory.None;
            }
        }

        private static void AddSurveyRelatedData(ModelBuilder modelBuilder)
        {
            var sortedDictionary = new SortedDictionary<string, List<string>>(dictionary,
                        Comparer<string>.Create(
                            (x, y) =>
                            {
                                return x.CompareTo(y);
                            }));

            foreach (var surveyQuestion in sortedDictionary)
            {
                Guid surveyQuestionGuid = Guid.NewGuid();
                modelBuilder.Entity<SurveyQuestion>().HasData(new SurveyQuestion()
                {
                    SurveyQuestionGUID = surveyQuestionGuid,
                    Value = surveyQuestion.Key.Split('?')[0] + '?',
                    Category = StringToCategory(surveyQuestion.Key.Split('?')[1])
                });
                List<SurveyAnswer> surveyAnswers = new();
                SurveyAnswer sa = new()
                {
                    SurveyQuestionGUID = surveyQuestionGuid,
                    SurveyAnswerGUID = Guid.NewGuid(),
                    Value = ""
                };
                if (surveyQuestion.Value.Count != 0)
                {
                    foreach (var surveyAnswer in surveyQuestion.Value)
                    {
                        sa.Value = surveyAnswer;

                        surveyAnswers.Add(sa);
                        modelBuilder.Entity<SurveyAnswer>().HasData(sa);
                    }
                    continue;
                }
                surveyAnswers.Add(sa);
                modelBuilder.Entity<SurveyAnswer>().HasData(sa);
            }
        }

        private static void AddUserData(ModelBuilder modelBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SurveyUserAnswer>()
                .HasOne(sua => sua.User)
                .WithMany(u => u.SurveyUserAnswers)
                .HasForeignKey(sua => sua.UserGUID);

            modelBuilder.Entity<SurveyUserAnswer>()
                .Navigation(x => x.SurveyAnswer)
                .IsRequired(false);

            modelBuilder.Entity<KnownFor>()
                .HasOne(k => k.Movie)
                .WithMany(m => m.KnowFor)
                .HasForeignKey(k => k.MovieGUID);

            modelBuilder.Entity<KnownFor>()
               .HasOne(k => k.Person)
               .WithMany(p => p.KnowFor)
               .HasForeignKey(k => k.PersonGUID);

            modelBuilder
                .Entity<SurveyAnswer>()
                .HasOne(sa => sa.SurveyQuestion)
                .WithMany(sq => sq.SurveyAnswers)
                .OnDelete(DeleteBehavior.Cascade);

            //AddSurveyRelatedData(modelBuilder);
            AddUserData(modelBuilder);
        }
    }
}