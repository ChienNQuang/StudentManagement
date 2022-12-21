using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Models.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(10)]
        public string Role { get; set; }
        public string Token { get; set; }
    }
}