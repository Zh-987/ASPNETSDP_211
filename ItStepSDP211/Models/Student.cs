using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItStepSDP211.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        
        public Student()
        {
            Courses = new List<Course>();
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
    }
}