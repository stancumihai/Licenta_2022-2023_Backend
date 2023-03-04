using Library.Models.Users;

namespace BLL.Converters.User
{
    public class UserTokenConverter
    {
        internal static UserToken ToBLLModel(DAL.Models.User userDALModel)
        {
            return new UserToken
            {
                Uid = userDALModel.UserGUID,
                Email = userDALModel.Email,
                Password = userDALModel.Password,
                Role = (Library.Enums.Roles)userDALModel.Role,
                RefreshToken = userDALModel.RefreshToken,
                TokenCreated = userDALModel.TokenCreated,
                TokenExpires = userDALModel.TokenExpires,
            };
        }
    }
}