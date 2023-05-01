using Library.Models.UserProfile;

namespace BLL.Interfaces
{
    public interface IUserProfiles
    {
        UserProfileCreate? Add(UserProfileCreate userProfile);
        UserProfileRead Update(UserProfileUpdate userProfile);
        List<UserProfileRead> GetAll();
        UserProfileRead? GetByGuid(Guid guid);
        UserProfileRead? GetByUserGuid(string userUid);
    }
}