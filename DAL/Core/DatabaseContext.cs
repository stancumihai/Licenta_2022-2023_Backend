using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core
{
    public class DatabaseContext : DbContext
    {
        private static string ConnectionString = "Database=Licenta;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
           => dbContext.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}