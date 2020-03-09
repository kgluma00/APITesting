using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.DTOs;
using ApiTest.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public StudentController(AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var x = _context.Students.ToList();

            return x;
        }

        [HttpPost]
        [Route("{studentId}/course")]
        public IActionResult AddNewCourseToExistingStudent(int studentId, Course model)
        {
            var course = _context.Courses.Add(model);
            _context.SaveChanges();
            _context.StudentCourses.Add(new StudentCourse { CourseId = course.Entity.Id, StudentId = studentId });
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("{studentId}/{courseId}")]
        public IActionResult AddExistingCourseToExistingStudent(int studentId, int courseId)
        {
            _context.StudentCourses.Add(new StudentCourse { StudentId = studentId, CourseId = courseId });
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("{schoolId}/school")]
        public IActionResult AddStudentToExistingSchool(int schoolId, Student model)
        {
            model.SchoolId = schoolId;
            _context.Students.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("{schoolId}/school/novalue")]
        public IActionResult AddStudentToExistingSchoolWithoutAddingModelSchoolIdValue(int schoolId, Student model)
        {
            var school = _context.Schools.Where(i => i.Id == schoolId).Single();
            model.School = school;
            _context.Students.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("{courseId}/students")]
        public List<StudentDto> GetAllStudentsWhoAreParticipatingInTheSelectedCourse(int courseId)
        {
            var students = _context.StudentCourses.Where(i => i.CourseId == courseId).Include(i => i.Student).ToList();
            var studentsList = new List<Student>();

            foreach (var item in students)
            {
                studentsList.Add(item.Student);
            }

            return _mapper.Map<List<Student>, List<StudentDto>>(studentsList);
        }

       
    }
}