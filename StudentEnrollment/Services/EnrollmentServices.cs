using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Services
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly StudentAPIContext _context;

        public EnrollmentServices(StudentAPIContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterStudentForCourse(Enrollment enrollment)
        {
            var course = await _context.Courses.FindAsync(enrollment.CourseId);
            if (course.Equals(null))
                return 0;

            var studentdata = await _context.Students.FindAsync(enrollment.StudentId);
            if (studentdata.Equals(null))
                return -1;

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollmentRecords()
        {
            return await _context.Enrollments.ToListAsync();
            //return await _context.Enrollments.Select(x=>new { EnrollmentId = x.EnrollmentID, Student = x.student, Course = x.course }).ToListAsync();
        }

        public async Task<dynamic> GetEnrollmentRecordsByStudentId(int studentid)
        {
            //await _context.Courses.LoadAsync();
            //await _context.Students.LoadAsync();
            var result = await _context.Enrollments.Where(x => x.StudentId == studentid).
                Select(x => new { EnrollmentId = x.EnrollmentID, Student = x.student, Course = x.course, 
                    Teacher = _context.Teachers.Where(t=>t.CourseId == x.CourseId).Select(
                        t=>new { TeacherId = t.TeacherID, TeacherName = t.name }).FirstOrDefault()}).ToListAsync();
            return result;
        }
    }
}
