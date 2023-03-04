using BLL.Converters.User;
using BLL.Core;
using BLL.Interfaces;
using Library.Models.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class UsersBL : BusinessObject, IUsers
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersBL(DAL.Interfaces.IDALContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserCreate Add(UserCreate user)
        {
            DAL.Models.User addedUser = UserCreateConverter.ToDALModel(user);
            return UserCreateConverter.ToBLLModel(_dalContext.Users.Add(addedUser));
        }

        public UserToken GetLoggedInUser()
        {
            var email = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            DAL.Models.User? user = _dalContext.Users.GetByEmail(email);
            if (user is null)
            {
                return null;
            }
            return UserTokenConverter.ToBLLModel(user);
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
        public void DeleteAll()
        {
            _dalContext.Users.DeleteAll();
        }
        public UserRead? GetByUid(Guid uid)
        {
            DAL.Models.User? user = _dalContext.Users.GetByUid(uid);
            if (user is null)
            {
                return null;
            }
            return UserReadConverter.ToBLLModel(user);
        }
        public UserRead? GetByEmail(string email)
        {
            DAL.Models.User? user = _dalContext.Users.GetByEmail(email);
            if (user is null)
            {
                return null;
            }
            return UserReadConverter.ToBLLModel(user);
        }
        public UserRead? GetByRefreshToken(string refreshToken)
        {
            DAL.Models.User? user = _dalContext.Users.GetByRefreshToken(refreshToken);
            if (user is null)
            {
                return null;
            }
            return UserReadConverter.ToBLLModel(user);
        }
    }
}