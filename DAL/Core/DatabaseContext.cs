using DAL.Enums;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core
{
    public class DatabaseContext : DbContext
    {
        private static readonly string ConnectionString = "Database=Licenta;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
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
            if (category == "Movie")
            {
                return SurveyQuestionCategory.Movie;
            }
            else if (category == "Actor")
            {
                return SurveyQuestionCategory.Actor;
            }
            else if (category == "Director")
            {
                return SurveyQuestionCategory.Director;

            }
            return SurveyQuestionCategory.None;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
            modelBuilder
                .Entity<User>()
                .HasMany(sa => sa.SurveyAnswers)
                .WithMany(u => u.Users)
                .UsingEntity(e => e.ToTable("SurveyAnswersUsers"));

            modelBuilder
                .Entity<SurveyAnswer>()
                .HasOne(sa => sa.SurveyQuestion)
                .WithMany(sq => sq.SurveyAnswers)
                .OnDelete(DeleteBehavior.Cascade);

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
                if (surveyQuestion.Value.Count != 0)
                {
                    foreach (var surveyAnswer in surveyQuestion.Value)
                    {
                        SurveyAnswer sa = new()
                        {
                            SurveyQuestionGUID = surveyQuestionGuid,
                            SurveyAnswerGUID = Guid.NewGuid(),
                            Value = surveyAnswer
                        };
                        surveyAnswers.Add(sa);
                        modelBuilder.Entity<SurveyAnswer>().HasData(sa);
                    }
                }
                else
                {
                    SurveyAnswer sa = new()
                    {
                        SurveyQuestionGUID = surveyQuestionGuid,
                        SurveyAnswerGUID = Guid.NewGuid()
                    };
                    surveyAnswers.Add(sa);
                    modelBuilder.Entity<SurveyAnswer>().HasData(sa);
                }
            }
        }
    }
}