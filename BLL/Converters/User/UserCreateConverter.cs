using Library.Models.Users;

namespace BLL.Converters.User
{
    public class UserCreateConverter
    {
        internal static UserCreate ToBLLModel(DAL.Models.User userDALModel)
        {
            return new UserCreate
            {
                Email = userDALModel.Email,
                Password = userDALModel.Password,
                PasswordHash = userDALModel.PasswordHash,
                PasswordSalt = userDALModel.PasswordSalt,
                RefreshToken = userDALModel.RefreshToken,
                TokenCreated = userDALModel.TokenCreated,
                TokenExpires = userDALModel.TokenExpires
            };
        }

        internal static DAL.Models.User ToDALModel(UserCreate userBLLModel)
        {
            return new DAL.Models.User
            {
                Email = userBLLModel.Email,
                Password = userBLLModel.Password,
                PasswordHash = userBLLModel.PasswordHash,
                PasswordSalt = userBLLModel.PasswordSalt,
                RefreshToken = userBLLModel.RefreshToken,
                TokenCreated = userBLLModel.TokenCreated,
                TokenExpires = userBLLModel.TokenExpires
            };
        }
    }
}