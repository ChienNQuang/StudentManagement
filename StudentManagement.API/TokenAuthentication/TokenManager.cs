using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using StudentManagement.API.Entities;
using StudentManagement.API.Helpers;
using StudentManagement.API.Models;
using StudentManagement.API.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace StudentManagement.API.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public TokenManager(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }
        public User Authenticate(string username, string password)
        {
            User user = _userService.GetUsers().FirstOrDefault(u => u.Username.ToLower() == username && u.Password == password);
            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        // public string NewToken()
        // {
        //     var tokenDescriptor = new SecurityTokenDescriptor()
        //     {
        //         Subject = new ClaimsIdentity( new Claim[] { new Claim(ClaimTypes.Name, "Chien")}),
        //         Expires = DateTime.UtcNow.AddMinutes(2),
        //         SigningCredentials = new SigningCredentials(
        //             new SymmetricSecurityKey(secretKey),
        //             SecurityAlgorithms.HmacSha256Signature)
        //     };

        //     SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        //     string stringToken = tokenHandler.WriteToken(token);

        //     return stringToken;
        // }

        // public ClaimsPrincipal VerifyToken(string token)
        // {
        //     var validationParameters = new TokenValidationParameters()
        //     {
        //         ValidateIssuerSigningKey = true,
        //         IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        //         ValidateLifetime = true,
        //         ValidateAudience = false,
        //         ValidateIssuer = false,
        //         ClockSkew = TimeSpan.Zero
        //     };
        //     var claims = tokenHandler.ValidateToken(token, 
        //                 validationParameters, 
        //                 out SecurityToken validatedToken);

        //     return claims;
        // }
    }
}