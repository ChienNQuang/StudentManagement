using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagement.API.Entities;
using StudentManagement.API.Helpers;

namespace StudentManagement.API.Services
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> students;
        public InMemoryStudentRepository()
        {
            students = new List<Student>(){
                new Student(){ Id = Guid.NewGuid(), FirstName = "Nguyen Quang", LastName = "Chien", DateOfBirth = DateTimeOffset.Parse("04/06/2003"), AverageScore = 8, Address = "BRVT", Username = "chiennqse171237", Password = "Chien2346", Role = Role.Student }
            };
        }
        public IEnumerable<Student> GetStudents() => students;

        public bool StudentExists(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            return students.Any(s => s.Id == studentId);
        }
        public Student GetStudent(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return students.FirstOrDefault(s => s.Id == studentId);
        }

        public void AddStudent(Student student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            string defaultUsername = student.LastName + student.FirstName + student.DateOfBirth.GetCurrentAge();
            string defaultPassword = student.FirstName + student.LastName;

            (student.Id, student.Role, student.Username, student.Password) 
            = (Guid.NewGuid(), Role.Student, defaultUsername, defaultPassword);
            
            students.Add(student);
        }

        public bool Save()
        {
            return true;
        }

        public void UpdateStudent(Student student)
        {
            
        }

        public void DeleteStudent(Student student)
        {
            students.Remove(student);
        }
    }
}