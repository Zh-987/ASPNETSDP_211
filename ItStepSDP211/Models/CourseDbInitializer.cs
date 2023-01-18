﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ItStepSDP211.Models
{
    public class CourseDbInitializer : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            Student s1 = new Student { Id = 1, Name = "Jhon"};
            Student s2 = new Student { Id = 2, Name = "Adam"};
            Student s3 = new Student { Id = 3, Name = "Alex"};

            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);

            Course c1 = new Course { Id = 1, Name = "Operation Systems",Students = new List<Student> { s1,s2,s3} };
            Course c2 = new Course { Id = 2, Name = "Database Systems", Students = new List<Student> { s1, s2 } };
            Course c3 = new Course { Id = 3, Name = "Hardware-Software Co-Design", Students = new List<Student> { s3 } };

            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);

            base.Seed(context);
        }
    }
}