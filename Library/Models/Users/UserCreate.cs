using Library.Enums;

namespace Library.Models.Users
{
    public class UserCreate
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}