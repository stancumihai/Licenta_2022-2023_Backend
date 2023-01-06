using BLL.Converters.User;
using BLL.Core;
using BLL.Interfaces;
using Library.Models.Users;

namespace BLL.Implementation
{
    public class UsersBL : BusinessObject, IUsers
    {
        public UsersBL(DAL.Interfaces.IDALContext dbContext) : base(dbContext)
        {
        }

        public UserCreate Add(UserCreate user)
        {
            DAL.Models.User addedUser = UserCreateConverter.ToDALModel(user);
            return UserCreateConverter.ToBLLModel(_dalContext.Users.Add(addedUser));
        }

        public List<UserRead> GetAll()
        {
            return _dalContext.Users.GetAll()
                .Select(user => UserReadConverter.ToBLLModel(user))
                .ToList();
        }

        public void Update(UserRead user)
        {
            DAL.Models.User user1 = UserReadConverter.ToDALModel(user);
            _dalContext.Users.Update(user1);
        }
        public void Delete(Guid uid)
        {
            if (_dalContext.Users.GetByUid(uid) == null)
            {
                return;
            }
            _dalContext.Users.Delete(uid);
        }

        public UserRead? GetByUid(Guid uid)
        {
            DAL.Models.User? user = _dalContext.Users.GetByUid(uid);
            if(user is null)
            {
                return null;
            }
            return UserReadConverter.ToBLLModel(user);
        }
    }
}