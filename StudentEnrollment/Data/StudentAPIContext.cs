using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class StudentAPIContext : DbContext
    {
        public StudentAPIContext(DbContextOptions<StudentAPIContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
