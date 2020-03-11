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

    //POSTMAN URL: http://localhost:5500/api

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public SchoolController(AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SaveSchool(School model)
        {
            _context.Schools.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public List<SchoolDto> GetAllSchools()
        {
            var schools = _context.Schools.ToList();

            return _mapper.Map<List<School>, List<SchoolDto>>(schools);
        }

        [HttpGet]
        [Route("{schoolId}")]
        public IActionResult GetSchoolById(int schoolId)
        {
            var school = _context.Schools.Where(i => i.Id == schoolId).Single();

            return Ok(_mapper.Map<School, SchoolDto>(school));
        }

        [HttpPost]
        [Route("{schoolId}/{courseId}")]
        public IActionResult AddExistingCourseToExistingSchool(int schoolId, int courseId)
        {
            _context.SchoolCourses.Add(new SchoolCourse { SchoolId = schoolId, CourseId = courseId });
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("{schoolId}/school")]
        public List<SchoolDto> GetAllCoursesWhichArePartOfTheSelectedSchool(int schoolId)
        {
            var schools = _context.SchoolCourses.Where(i => i.SchoolId == schoolId).Include(co => co.School).ToList();
            var schoolList = new List<School>();

            foreach (var item in schools)
            {
                schoolList.Add(item.School);
            }

            return _mapper.Map<List<School>, List<SchoolDto>>(schoolList);
        }

    }
}