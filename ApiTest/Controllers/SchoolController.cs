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
    public class SchoolController : ControllerBase
    {
        private readonly AppContext _context;

        public SchoolController(AppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SaveSchool(School model)
        {
            _context.Schools.Add(model);
            _context.SaveChanges();

            return Ok();
        }
    }
}