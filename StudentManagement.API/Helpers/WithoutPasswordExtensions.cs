using System.Collections.Generic;
using System.Linq;
using StudentManagement.API.Models.Entities;

namespace StudentManagement.API.Helpers
{
    public static class WithoutPasswordExtensions
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users) 
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user) 
        {
            if (user == null) return null;

            user.Password = null;
            return user;
        }
    }
}