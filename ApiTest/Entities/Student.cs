using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public string StudentName { get; set; }
        public School School { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
