using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserProfiles
    {
        UserProfile? Add(UserProfile userProfile);
        UserProfile Update(UserProfile userProfile);
        List<UserProfile> GetAll();
        UserProfile? GetByGuid(Guid guid);
        UserProfile? GetByUserGuid(string userGUID);
    }
}