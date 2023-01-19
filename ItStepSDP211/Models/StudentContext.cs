using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ItStepSDP211.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(c => c.Students).WithMany(s => s.Courses).Map(t => t.MapLeftKey("CourseId").MapRightKey("StudentId").ToTable("CourseStudent"));
            base.OnModelCreating(modelBuilder);
        }
    }
}