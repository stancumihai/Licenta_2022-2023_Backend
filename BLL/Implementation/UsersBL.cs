using BLL.Converters.User;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.Users;

namespace BLL.Implementation
{
    public class UsersBL : BusinessObject, IUsers
    {
        public UsersBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public UserRead GetByUid(Guid uid)
        {
            return UserReadConverter.ToBLLModel(_dalContext.Users.GetByUid(uid)!);
        }
        public List<UserRead> GetAll()
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            return users.Select(user => UserReadConverter.ToBLLModel(user)).ToList();
        }

        public UserRead GetByEmail(string email)
        {
            return UserReadConverter.ToBLLModel(_dalContext.Users.GetByEmail(email)!);
        }

        public void Update(UserRead user)
        {
            ApplicationUser userToUpdate = UserReadConverter.ToDALModel(user);
            _dalContext.Users.Update(userToUpdate);
        }
    }
}