using Library.Models.Users;

namespace BLL.Interfaces
{
    public interface IUsers
    {
        UserCreate Add(UserCreate user);
        List<UserRead> GetAll();
        void Update(UserRead user);
        void Delete(Guid uid);
        UserRead? GetByUid(Guid uid);
    }
}