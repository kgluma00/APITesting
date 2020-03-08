using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppContext _context;

        public StudentController(AppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var x = _context.Students.ToList();

            return x;
        }

        [HttpPost]
        public IActionResult SaveStudent(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("{id}/course")]
        public IActionResult AddNewCourseToExistingStudent(int id, Course model)
        {
            var student = _context.Students.Single(st => st.Id == id);
            var course = _context.Courses.Add(model);
            _context.SaveChanges();
            var studentCourse = _context.StudentCourses.Add(new StudentCourse { CourseId = course.Entity.Id, StudentId = student.Id });
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("{studentId}/{courseId}")]
        public IActionResult AddExistingCourseToExistingStudent(int studentId, int courseId)
        {
            var student = _context.Students.Single(st => st.Id == studentId);
            var course = _context.Courses.Single(co => co.Id == courseId);
            var studentCourse = _context.StudentCourses.Add(new StudentCourse { StudentId = studentId, CourseId = courseId });
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
    }
}