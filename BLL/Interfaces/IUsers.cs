using Library.Models.Users;

namespace BLL.Interfaces
{
    public interface IUsers
    {
        UserCreate Add(UserCreate user);
        List<UserRead> GetAll();
        void Update(UserRead user);
        void Delete(Guid uid);
        void DeleteAll();
        UserRead? GetByUid(Guid uid);
        UserRead? GetByEmail(string email);
        UserRead? GetByRefreshToken(string refreshToken);
        UserToken GetLoggedInUser();
    }
}