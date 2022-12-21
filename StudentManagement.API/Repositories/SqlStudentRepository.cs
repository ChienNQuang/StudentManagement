using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentManagement.API.DbContexts;
using StudentManagement.API.Entities;

namespace StudentManagement.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentManagementDbContext _context;

        public SqlStudentRepository(StudentManagementDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddStudent(Student student)
        {
            _context.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _context.Remove(student);
        }

        public Student GetStudent(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _context.Students.Where(s => s.Id == studentId).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.AsNoTracking().ToList<Student>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool StudentExists(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _context.Students.Any(s => s.Id == studentId);
        }

        public void UpdateStudent(Student student)
        {
            
        }
    }
}