using DAL.Core;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class UserProfiles : DALObject, IUserProfiles
    {
        public UserProfiles(DatabaseContext context) : base(context)
        {
        }

        public UserProfile? Add(UserProfile userProfile)
        {
            ApplicationUser? existingUser = _context.Users.Find(userProfile.UserGUID);
            if (existingUser == null)
            {
                return null;
            }
            UserProfile addedUserProfile = _context.UserProfiles.Add(userProfile).Entity;
            _context.SaveChanges();
            return addedUserProfile;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfiles.ToList();
        }

        public UserProfile? GetByGuid(Guid guid)
        {
            UserProfile? userProfile = _context.UserProfiles.FirstOrDefault(up => up.UserProfileGUID == guid);
            if (userProfile == null)
            {
                return null;
            }
            return userProfile;
        }

        public UserProfile? GetByUserGuid(string userGUID)
        {
            UserProfile? userProfile = _context.UserProfiles.FirstOrDefault(up => up.UserGUID == userGUID);
            if (userProfile == null)
            {
                return null;
            }
            return userProfile;
        }

        public UserProfile Update(UserProfile newUserProfile)
        {
            UserProfile? oldUserProfile = _context.UserProfiles.FirstOrDefault(up => up.UserProfileGUID == newUserProfile.UserProfileGUID);
            if (oldUserProfile == null)
            {
                return null;
            }
            UpdateFields(oldUserProfile, newUserProfile);
            _context.UserProfiles.Update(oldUserProfile);
            _context.SaveChanges();
            return newUserProfile;
        }

        private static void UpdateFields(UserProfile oldUserProfile, UserProfile newUserProfile)
        {
            oldUserProfile.City = newUserProfile.City;
            oldUserProfile.Country = newUserProfile.Country;
            oldUserProfile.FullName = newUserProfile.FullName;
        }
    }
}