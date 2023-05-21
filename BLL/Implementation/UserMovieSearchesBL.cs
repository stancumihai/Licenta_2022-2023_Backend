using BLL.Converters.UserMovieSearch;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.UserMovieSearch;

namespace BLL.Implementation
{
    public class UserMovieSearchesBL : BusinessObject, IUserMovieSearches
    {
        public UserMovieSearchesBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public UserMovieSearchCreate Add(UserMovieSearchCreate userMovieSearchCreate)
        {
            UserMovieSearch? addedUserMovieSearch = _dalContext.UserMovieSearches.Add(UserMovieSearchCreateConverter.ToDALModel(userMovieSearchCreate));
            if (addedUserMovieSearch == null)
            {
                return null;
            }
            return UserMovieSearchCreateConverter.ToBLLModel(addedUserMovieSearch);
        }
    }
}