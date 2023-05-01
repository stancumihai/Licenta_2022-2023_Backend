using Library.Models.UserProfile;

namespace BLL.Converters.UserProfile
{
    public class UserProfileReadConverter
    {
        public static UserProfileRead ToBLLModel(DAL.Models.UserProfile userProfileDALModel)
        {
            UserProfileRead userProfileRead = new()
            {
                Uid = userProfileDALModel.UserProfileGUID,
                UserUid = userProfileDALModel.UserGUID,
                City = userProfileDALModel.City,
                Country = userProfileDALModel.Country,
                DateOfBirth = userProfileDALModel.DateOfBirth,
                FullName = userProfileDALModel.FullName,
            };
            return userProfileRead;
        }

        public static DAL.Models.UserProfile ToDALModel(UserProfileRead userProfileBLLModel)
        {
            DAL.Models.UserProfile userProfileEntity = new()
            {
                UserProfileGUID = userProfileBLLModel.Uid,
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
