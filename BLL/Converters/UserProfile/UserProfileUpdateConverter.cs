using Library.Models.UserProfile;

namespace BLL.Converters.UserProfile
{
    public class UserProfileUpdateConverter
    {
        public static UserProfileUpdate ToBLLModel(DAL.Models.UserProfile userProfileDALModel)
        {
            UserProfileUpdate userProfileUpdate = new()
            {
                Uid = userProfileDALModel.UserProfileGUID,
                City = userProfileDALModel.City,
                Country = userProfileDALModel.Country,
                FullName = userProfileDALModel.FullName,
            };
            return userProfileUpdate;
        }

        public static DAL.Models.UserProfile ToDALModel(UserProfileUpdate userProfileBLLModel)
        {
            DAL.Models.UserProfile userProfileEntity = new()
            {
                UserProfileGUID = userProfileBLLModel.Uid,
                City = userProfileBLLModel.City,
                Country = userProfileBLLModel.Country,
                FullName = userProfileBLLModel.FullName,
            };
            return userProfileEntity;
        }
    }
}