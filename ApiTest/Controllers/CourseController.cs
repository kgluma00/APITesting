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
    public class CourseController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;
        public CourseController(AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SaveCourse(Course model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("{studentId}/courses")]
        public List<CourseDto> GetAllCoursesWhichAreParticipatedBySelectedStudent(int studentId)
        {
            var courses = _context.StudentCourses.Where(i => i.StudentId == studentId).Include(c => c.Course).ToList();
            var listaKurseva = new List<Course>();

            foreach (var item in courses)
            {
                listaKurseva.Add(item.Course);
            }

            return _mapper.Map<List<Course>, List<CourseDto>>(listaKurseva);
        }
    }
}