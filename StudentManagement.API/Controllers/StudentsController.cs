using System;
using System.Collections.Generic;
using AutoMapper;
using StudentManagement.API.Models;
using StudentManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models.DTOs;
using StudentManagement.API.Models.Entities;
using StudentManagement.API.Repositories;

namespace StudentManagement.API.Controllers
{
    [Produces("application/json", "application/xml")]
    [Authorize(Roles = Role.Admin + ", " + Role.Student)]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of students
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of StudentDto</returns>
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudents()
        {
            IEnumerable<Student> studentsFromRepo = _studentRepo.GetStudents();

            return Ok(_mapper.Map<IEnumerable<StudentDto>>(studentsFromRepo));
        }

        /// <summary>
        /// Get a student by his/her id
        /// </summary>
        /// <param name="studentId">The id of the student you want to get</param>
        /// <returns>An ActionResult of type StudentDto</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{studentId}", Name = "GetStudent")]
        public ActionResult<StudentDto> GetStudent(Guid studentId)
        {
            if (!_studentRepo.StudentExists(studentId))
            {
                return NotFound();
            }
            
            Student student = _studentRepo.GetStudent(studentId);

            return Ok(_mapper.Map<StudentDto>(student));
        }

        /// <summary>
        /// Create a student
        /// </summary>
        /// <param name="student">The student to be created</param>
        /// <returns>An ActionResult of type StudentDto</returns>
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<StudentDto> CreateStudent(StudentForCreationDto student)
        {
            Student studentToAdd = _mapper.Map<Student>(student);

            _studentRepo.AddStudent(studentToAdd);
            _studentRepo.Save();

            StudentDto studentToReturn = _mapper.Map<StudentDto>(studentToAdd);

            return CreatedAtRoute("GetStudent", 
                                  new { studentId = studentToReturn.Id }, 
                                  studentToReturn);
        }

        /// <summary>
        /// Update a specific student
        /// </summary>
        /// <param name="studentId">The id of the student to be modified</param>
        /// <param name="student">The student with updated values</param>
        /// <returns>An ActionResult of type StudentDto</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{studentId}")]
        public IActionResult UpdateStudent(Guid studentId, StudentForUpdateDto student)
        {
            if (!_studentRepo.StudentExists(studentId))
            {
                return NotFound();
            }

            Student studentFromRepo = _studentRepo.GetStudent(studentId);

            _mapper.Map(student, studentFromRepo);

            _studentRepo.UpdateStudent(studentFromRepo);
            _studentRepo.Save();

            return NoContent();
        }

        /// <summary>
        /// Delete a student
        /// </summary>
        /// <param name="studentId">The id of the student to be deleted</param>
        /// <returns>An IActionResult</returns>
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{studentId}")]
        public IActionResult DeleteStudent(Guid studentId)
        {
            if (!_studentRepo.StudentExists(studentId))
            {
                return NotFound();
            }

            Student studentToDelete = _studentRepo.GetStudent(studentId);

            _studentRepo.DeleteStudent(studentToDelete);
            _studentRepo.Save();

            return NoContent();
        }
    }
}