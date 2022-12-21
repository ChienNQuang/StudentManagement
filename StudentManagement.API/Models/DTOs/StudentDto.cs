using System;

namespace StudentManagement.API.Models.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double AverageScore { get; set; }
        public string Address { get; set; }
    }
}