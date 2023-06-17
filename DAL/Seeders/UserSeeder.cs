using DAL.Core;
using DAL.Interfaces;
using DAL.Models;
using Library.Enums;
using Library.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Text.RegularExpressions;

namespace DAL.Seeders
{
    public class UserSeeder : DALObject, IUserSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserSeeder(DatabaseContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public readonly string[] userNames = { "andreaEvans", "earnestMcguire", "robertoHarmon", "rosieJacobs", "triciaQuinn" ,
                                    "vernaDaniel","lauraWilliams" , "oscarFoster" , "jodyReynolds" , "bennieEdwards",
                                    "dannyHopkins", "russellAlvarez", "wandaDoyle", "albertAllen", "cesarCooper",
                                    "matthewMccormick" };

        public async Task SeedAdditionalData(int year, int month)
        {
            List<ApplicationUser> applicationUsers = _context.Users.ToList();
            foreach (ApplicationUser user in applicationUsers)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                if (roles.FirstOrDefault(r => r == "Administrator") != null)
                {
                    return;
                }
                DateTime dateTime = new(year, month, 1);
                CreateUserProfile(user.Id, _context.Users.FirstOrDefault(u => u.Id == user.Id)!.UserName);
                //CreateUserSeenMovies(user.Id, dateTime);
                //CreateUserMovieSearches(user.Id, dateTime);
                //CreateMovieSubscriptions(user.Id, dateTime);
                //CreateLikedMovies(user.Id, dateTime);
            }
        }

        public async Task SeedUsers()
        {
            foreach (string userName in userNames)
            {
                await ProcessSingleUser(userName);
            }
        }
        private async Task ProcessSingleUser(string userName)
        {
            string userEmail = GetUserEmail(userName);
            if (_context.Users.FirstOrDefault(u => u.Email == userEmail) == null)
            {
                UserRegister userRegister = new()
                {
                    Email = userEmail,
                    Password = "@Dev123"
                };
                ApplicationUser user = await CreateUser(userRegister);
                if (user != null)
                {
                    CreateUserProfile(user.Id, userName);
                    //CreateUserSeenMovies(user.Id);
                    //CreateMovieSubscriptions(user.Id);
                    //CreateLikedMovies(user.Id);
                    //CreateUserMovieSearches(user.Id);
                }
            }
        }

        private static string GetUserEmail(string userName)
        {
            return userName + "@yahoo.com";
        }

        private static string GetUserFullName(string userName)
        {
            string[] fullNameSplit = Regex.Split(userName, @"(?<!^)(?=[A-Z])");
            if (fullNameSplit.Length == 0)
            {
                return "";
            }
            if (fullNameSplit.Length == 1)
            {
                return fullNameSplit[0];
            }
            return fullNameSplit[0] + fullNameSplit[1];
        }

        private static DateTime GenerateDate()
        {
            DateTime start = new(1995, 1, 1);
            DateTime max = new(2007, 12, 31);
            DateTime min = new(1970, 1, 1);
            Random random = new();
            int range = (DateTime.Today - start).Days;
            DateTime newDate = start.AddDays(random.Next(range));
            while (newDate > max)
            {
                newDate = newDate.AddYears(-1);
            }
            while (newDate < min)
            {
                newDate = newDate.AddYears(1);
            }
            return newDate;
        }

        private static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private async Task<ApplicationUser> CreateUser(UserRegister model)
        {
            Guid newUserGuid = Guid.NewGuid();
            ApplicationUser user = new()
            {
                Id = newUserGuid.ToString(),
                Password = EncodePasswordToBase64(model.Password),
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                SurveyUserAnswers = new List<SurveyUserAnswer>()
            };
            IdentityResult? result = await _userManager.CreateAsync(user, model.Password);
            if (await _roleManager.RoleExistsAsync(UserRoles.Member))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Member);
            }
            if (!result.Succeeded)
            {
                return null;
            }
            return user;
        }


        private void CreateUserProfile(string userId, string userName)
        {
            Random random = new();
            string userFullName = GetUserFullName(userName);
            UserProfile userProfile = new()
            {
                UserProfileGUID = Guid.NewGuid(),
                UserGUID = userId,
                DateOfBirth = GenerateDate(),
                City = "City " + random.Next(100),
                Country = "Country " + random.Next(100),
                FullName = userFullName
            };
            if (_context.UserProfiles.FirstOrDefault(f => f.FullName == userFullName) == null)
            {
                _context.UserProfiles.Add(userProfile);
                _context.SaveChanges();
            }
        }

        private void AddUserMovieRating(Random random, Guid movieGuid, string userId, DateTime createdAt)
        {
            UserMovieRating userMovieRating = new()
            {
                UserMovieRatingGUID = new Guid(),
                MovieGUID = movieGuid,
                UserGUID = userId,
                Rating = random.NextInt64(1, 5),
                CreatedAt = createdAt
            };
            _context.UserMovieRatings.Add(userMovieRating);
        }

        private void CreateUserSeenMovies(string userId, DateTime dateTime = default)
        {
            int count = 0;
            List<Movie> movies = _context.Movies.ToList();
            while (count <= 30)
            {
                count++;
                Random random = new();
                int movieIndex = random.Next(movies.Count);
                DateTime createdAt = DateTime.Now;
                if (dateTime != default)
                {
                    createdAt = dateTime;
                }
                else
                {
                    if ((count - 1) % 5 == 0)
                    {
                        int addedMonths = count / 5;
                        createdAt = createdAt.AddMonths(addedMonths);
                    }
                }
                SeenMovie seenMovie = new()
                {
                    SeenMovieGUID = new Guid(),
                    MovieGUID = movies[movieIndex].MovieGUID,
                    UserGUID = userId,
                    CreatedAt = createdAt,
                };
                _context.SeenMovies.Add(seenMovie);
                AddUserMovieRating(random, movies[movieIndex].MovieGUID, userId, createdAt);
                _context.SaveChanges();
            }
        }

        private void CreateMovieSubscriptions(string userId, DateTime dateTime = default)
        {
            int count = 0;
            List<Movie> movies = _context.Movies.ToList();
            while (count <= 30)
            {
                count++;
                Random random = new();
                int movieIndex = random.Next(movies.Count);
                DateTime createdAt = DateTime.Now;
                if (dateTime != default)
                {
                    createdAt = dateTime;
                }
                else
                {
                    if ((count - 1) % 3 == 0)
                    {
                        createdAt = createdAt.AddMonths(count / 3);
                    }
                }
                MovieSubscription movieSubscription = new()
                {
                    MovieSubscriptionGUID = new Guid(),
                    MovieGUID = movies[movieIndex].MovieGUID,
                    UserGUID = userId,
                    CreatedAt = createdAt
                };
                _context.MovieSubscriptions.Add(movieSubscription);
                _context.SaveChanges();
            }
        }

        private void CreateLikedMovies(string userId, DateTime dateTime = default)
        {
            int count = 0;
            List<Movie> movies = _context.Movies.ToList();
            while (count <= 30)
            {
                count++;
                Random random = new();
                int movieIndex = random.Next(movies.Count);
                DateTime createdAt = DateTime.Now;
                if (dateTime != default)
                {
                    createdAt = dateTime;
                }
                else
                {
                    if ((count - 1) % 5 == 0)
                    {
                        int addedMonths = count / 5;
                        createdAt = createdAt.AddMonths(addedMonths);
                    }
                }
                LikedMovie likedMovie = new()
                {
                    LikedMovieGUID = new Guid(),
                    MovieGUID = movies[movieIndex].MovieGUID,
                    UserGUID = userId,
                    CreatedAt = createdAt,
                };
                _context.LikedMovies.Add(likedMovie);
                _context.SaveChanges();
            }
        }

        private void CreateUserMovieSearches(string userId, DateTime dateTime = default)
        {
            int count = 0;
            List<Movie> movies = _context.Movies.ToList();
            while (count <= 60)
            {
                count++;
                Random random = new();
                int movieIndex = random.Next(movies.Count);
                DateTime createdAt = DateTime.Now;
                if (dateTime != default)
                {
                    createdAt = dateTime;
                }
                else
                {
                    if ((count - 1) % 5 == 0)
                    {
                        int addedMonths = count / 5;
                        createdAt = createdAt.AddMonths(addedMonths);
                    }
                }
                UserMovieSearch userMovieSearch = new()
                {
                    UserMovieSearchGUID = new Guid(),
                    MovieGUID = movies[movieIndex].MovieGUID,
                    UserGUID = userId,
                    CreatedAt = createdAt,
                };
                _context.UserMovieSearches.Add(userMovieSearch);
                _context.SaveChanges();
            }
        }
    }
}