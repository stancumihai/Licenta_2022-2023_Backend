using Library.Models.Users;

namespace BLL.Converters.User
{
    public class UserCreateConverter
    {
        internal static UserCreate ToBLLModel(DAL.Models.User userDALModel)
        {
            return new UserCreate
            {
                Username = userDALModel.Username,
                Email = userDALModel.Email,
                Password = userDALModel.Password,
            };
        }

        internal static DAL.Models.User ToDALModel(UserCreate userBLLModel)
        {
            return new DAL.Models.User
            {
                Username = userBLLModel.Username,
                Email = userBLLModel.Email,
                Password = userBLLModel.Password,
            };
        }
    }
}