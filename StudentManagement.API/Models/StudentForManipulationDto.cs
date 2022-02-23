using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Models
{
    public abstract class StudentForManipulationDto
    {
        [Required(ErrorMessage = "You have to fill out FirstName")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You have to fill out LastName")]
        [MaxLength(100)]
        public string LastName { get; set; }
        
        public virtual DateTimeOffset DateOfBirth { get; set; }// = DateTimeOffset.Parse("2000-01-01T00:00:00");

        [Range(0.0, 10.0)]
        public virtual double AverageScore { get; set; } = 0;

        [MaxLength(50)]
        public virtual string Address { get; set; }
    }
}