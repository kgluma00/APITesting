using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<SchoolCourse> SchoolCourses { get; set; }
    }
}
