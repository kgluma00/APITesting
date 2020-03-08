using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Entities
{
    public class SchoolCourse
    {
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
