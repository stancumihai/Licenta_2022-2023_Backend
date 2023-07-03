namespace DAL.Interfaces
{
    public interface IUserSeeder
    {
        Task SeedUsers();
        Task SeedAdditionalData(int year, int month);
        void SeedRecommendationOutcomes(int year, int month, float accuracy, float seenPercent);
    }
}