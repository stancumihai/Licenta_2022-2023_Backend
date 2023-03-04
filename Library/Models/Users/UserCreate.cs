using Library.Enums;

namespace Library.Models.Users
{
    public class UserCreate
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public Roles Role { get; set; }
    }
}