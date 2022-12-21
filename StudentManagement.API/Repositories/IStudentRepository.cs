using System;
using System.Collections.Generic;
using StudentManagement.API.Entities;

namespace StudentManagement.API.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(Guid studentId);
        bool StudentExists(Guid studentId);
        void AddStudent(Student student);
        bool Save();
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}