using BLL.Converters.UserProfile;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.UserProfile;

namespace BLL.Implementation
{
    public class UserProfilesBL : BusinessObject, IUserProfiles
    {

        public UserProfilesBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public UserProfileCreate? Add(UserProfileCreate userProfile)
        {
            UserProfile? addedUserProfile = _dalContext.UserProfiles.Add(UserProfileCreateConverter.ToDALModel(userProfile));
            if (addedUserProfile == null)
            {
                return null;
            }
            return UserProfileCreateConverter.ToBLLModel(addedUserProfile);
        }

        public List<UserProfileRead> GetAll()
        {
            return _dalContext.UserProfiles
                .GetAll()
                .Select(up => UserProfileReadConverter.ToBLLModel(up)).ToList();
        }

        public UserProfileRead? GetByGuid(Guid guid)
        {
            UserProfile? existingUserProfile = _dalContext.UserProfiles.GetByGuid(guid);
            if (existingUserProfile == null)
            {
                return null;
            }
            return UserProfileReadConverter.ToBLLModel(existingUserProfile);
        }

        public UserProfileRead? Update(UserProfileUpdate userProfile)
        {
            UserProfile? existingUserProfile = _dalContext.UserProfiles.GetByGuid(userProfile.Uid);
            if (existingUserProfile == null)
            {
                return null;
            }
            UserProfile userProfileDalModel = UserProfileUpdateConverter.ToDALModel(userProfile);
            userProfileDalModel.UserGUID = existingUserProfile.UserGUID;
            userProfileDalModel.DateOfBirth = existingUserProfile.DateOfBirth;
            _dalContext.UserProfiles.Update(userProfileDalModel);
            return UserProfileReadConverter.ToBLLModel(userProfileDalModel);
        }

        public UserProfileRead? GetByUserGuid(string userUid)
        {
            UserProfile? existingUserProfile = _dalContext.UserProfiles.GetByUserGuid(userUid);
            if (existingUserProfile == null)
            {
                return null;
            }
            return UserProfileReadConverter.ToBLLModel(existingUserProfile);
        }
    }
}