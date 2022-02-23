using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Entities
{
    public class Student : User
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        [Range(0.0, 10.0)]
        public double AverageScore { get; set; }
        public string Address { get; set; }
    }
}