using Library.Models.UserProfile;

namespace BLL.Converters.UserProfile
{
    public class UserProfileCreateConverter
    {
        public static UserProfileCreate ToBLLModel(DAL.Models.UserProfile userProfileDALModel)
        {
            UserProfileCreate userProfileCreate = new()
            {
                UserUid = userProfileDALModel.UserGUID,
                City = userProfileDALModel.City,
                Country = userProfileDALModel.Country,
                DateOfBirth = userProfileDALModel.DateOfBirth,
                FullName = userProfileDALModel.FullName,
            };
            return userProfileCreate;
        }

        public static DAL.Models.UserProfile ToDALModel(UserProfileCreate userProfileBLLModel)
        {
            DAL.Models.UserProfile userProfileEntity = new()
            {
                UserGUID = userProfileBLLModel.UserUid,
                City = userProfileBLLModel.City,
                Country = userProfileBLLModel.Country,
                DateOfBirth = userProfileBLLModel.DateOfBirth,
                FullName = userProfileBLLModel.FullName,
            };
            return userProfileEntity;
        }
    }
}