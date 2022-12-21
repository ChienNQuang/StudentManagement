using System.Security.Claims;
using StudentManagement.API.Models;
using StudentManagement.API.Models.Entities;

namespace StudentManagement.API.TokenAuthentication
{
    public interface ITokenManager
    {
         User Authenticate(string username, string password);
    }
}