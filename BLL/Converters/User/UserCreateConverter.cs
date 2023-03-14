using DAL.Models;
using Library.Models.Users;

namespace BLL.Converters.User
{
    public class UserCreateConverter
    {
        internal static UserRegister ToBLLModel(ApplicationUser userDALModel)
        {
            return new UserRegister
            {
                Email = userDALModel.Email,
                Password = userDALModel.Password,
            };
        }

        internal static ApplicationUser ToDALModel(UserRegister userBLLModel)
        {
            return new ApplicationUser
            {
                Email = userBLLModel.Email,
                Password = userBLLModel.Password,
            };
        }
    }
}