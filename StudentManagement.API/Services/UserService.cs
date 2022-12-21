using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StudentManagement.API.DbContexts;
using StudentManagement.API.Models.Entities;

namespace StudentManagement.API.Services
{
    public class UserService : IUserService
    {
        private readonly IEnumerable<User> _users;
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public UserService(StudentManagementDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _users = _context.Admins.ToList().Concat(_mapper.Map<List<User>>(_context.Students.ToList()));
        }

        public IEnumerable<User> GetUsers() => _users.OrderBy(u => u.Role);

        public User GetUser(Guid userId)
        {
            User user = _users.FirstOrDefault(u => u.Id == userId);
            
            if (user == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return user;
        }
    }
}