using Library.Models.Users;

namespace BLL.Interfaces
{
    public interface IUsers
    {
        UserRead GetByUid(Guid uid);
        UserRead GetByEmail(string email);
        List<UserRead> GetAll();
        void Update(UserRead user);
    }
}