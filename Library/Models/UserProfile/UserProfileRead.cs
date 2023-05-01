﻿namespace Library.Models.UserProfile
{
    public class UserProfileRead
    {
        public Guid Uid { get; set; }
        public string UserUid { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}