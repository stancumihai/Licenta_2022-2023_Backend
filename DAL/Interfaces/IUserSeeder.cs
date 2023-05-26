namespace DAL.Interfaces
{
    public interface IUserSeeder
    {
        Task SeedUsers();
        Task SeedAdditionalData(int year, int month);
    }
}