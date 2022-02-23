using System.Security.Claims;
using StudentManagement.API.Entities;
using StudentManagement.API.Models;

namespace StudentManagement.API.TokenAuthentication
{
    public interface ITokenManager
    {
         User Authenticate(string username, string password);
        //  string NewToken();
        //  ClaimsPrincipal VerifyToken(string token);
    }
}