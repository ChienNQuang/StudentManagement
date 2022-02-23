using System;
using System.Collections.Generic;
using StudentManagement.API.Entities;

namespace StudentManagement.API.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid userId);
    }
}