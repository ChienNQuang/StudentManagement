using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using StudentManagement.API.DbContexts;
using StudentManagement.API.Entities;
using StudentManagement.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace StudentManagement.API.Services
{
    public class UserService : IUserService
    {
        private readonly IEnumerable<User> users;
        private readonly IStudentRepository _studentRepo;
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public UserService(IStudentRepository studentRepo, StudentManagementDbContext context, IMapper mapper)
        {
            _studentRepo = studentRepo ?? throw new ArgumentNullException(nameof(studentRepo));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            users = _context.Admins.ToList().Concat(_mapper.Map<List<User>>(_context.Students.ToList()));
        }

        public IEnumerable<User> GetUsers() => users.OrderBy(u => u.Role);

        public User GetUser(Guid userId)
        {
            User user = users.FirstOrDefault(u => u.Id == userId);
            
            if (user == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return user;
        }
        // public User Authenticate(string username, string password)
        // {
        //     User user = users.FirstOrDefault(u => u.Username.ToLower() == username && u.Password == password);
        //     if (user == null)
        //     {
        //         return null;
        //     }

        //     // authentication successful so generate jwt token
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
        //     var tokenDescriptor = new SecurityTokenDescriptor()
        //     {
        //         Subject = new ClaimsIdentity(new Claim[] 
        //         {
        //             new Claim(ClaimTypes.Name, user.Id.ToString()),
        //             new Claim(ClaimTypes.Role, user.Role)
        //         }),
        //         Expires = DateTime.UtcNow.AddDays(7),
        //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //     };
        //     var token = tokenHandler.CreateToken(tokenDescriptor);
        //     user.Token = tokenHandler.WriteToken(token);

        //     return user.WithoutPassword();
        // }
    }
}