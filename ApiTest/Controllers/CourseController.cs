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
    public class CourseController : ControllerBase
    {
        private readonly AppContext _context;

        public CourseController(AppContext contect)
        {
            _context = contect;
        }

        [HttpPost]
        public IActionResult SaveCourse(Course model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();

            return Ok();
        }
    }
}