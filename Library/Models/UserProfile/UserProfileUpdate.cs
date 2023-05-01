namespace Library.Models.UserProfile
{
    public class UserProfileUpdate
    {
        public Guid Uid { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}