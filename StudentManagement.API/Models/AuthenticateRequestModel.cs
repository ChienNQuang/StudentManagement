using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Models
{
    public class AuthenticateRequestModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}