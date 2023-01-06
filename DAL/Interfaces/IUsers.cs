﻿using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUsers
    {
        User Add(User user);
        List<User> GetAll();
        void Delete(Guid uid);
        void Update(User user);
        User? GetByUid(Guid uid);
    }
}