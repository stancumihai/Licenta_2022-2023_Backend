using Library.Models.Security;
using Library.Models.Users;
using System.IdentityModel.Tokens.Jwt;

namespace BLL.Interfaces
{
    public interface IAuthentication
    {
        Task<UserRegister> Register(UserRegister user);
        Task<UserRegister> RegisterAdmin(UserRegister user);
        Task<Tuple<JwtSecurityToken, string>> Login(UserLogin user);
        Task<Tuple<JwtSecurityToken, string>> RefreshToken(TokenModel tokenModel);
        Task<bool> Revoke(string email);
        Task<bool> RevokeAll();
        Task<bool> Logout();
        Task<UserRead> GetLoggedInUser();
        Task<string> GetUserDecodedPasswordByEmail(string email);
        void UpdatePassword(UserRead userToUpdate, string newPassword);
    }
}