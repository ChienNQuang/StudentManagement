using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Models.DTOs
{
    public class StudentForUpdateDto : StudentForManipulationDto
    {
        [Required(ErrorMessage = "Date of birth required")]
        public override DateTimeOffset DateOfBirth { get; set; }

        [Required(ErrorMessage = "You should fill out the score")]
        public override double AverageScore { get; set; }

        [Required(ErrorMessage = "You should fill out the address")]
        public override string Address { get; set; }
    }
}