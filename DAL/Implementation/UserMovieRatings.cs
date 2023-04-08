using DAL.Core;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class UserMovieRatings : DALObject, IUserMovieRatings
    {
        public UserMovieRatings(DatabaseContext context) : base(context)
        {
        }
    }
}