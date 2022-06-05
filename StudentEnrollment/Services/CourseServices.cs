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
    public class CourseServices : ICourseServices
    {
        private readonly StudentAPIContext _context;

        public CourseServices(StudentAPIContext context)
        {
            _context = context;
        }

        public async Task<string> AddCourse(Course course)
        {
            var entry = _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return $"Course {course.title} created with id {course.CourseID}";
        }

        /*
        public async Task<int> RegisterStudentForCourse(int studentid, int courseid)
        {
            var course = await _context.Courses.FindAsync(courseid);
            if (course.Equals(null))
                return 0;
            
            var studentdata = await _context.Students.FindAsync(studentid);
            if (studentdata.Equals(null))
                return -1;

            //course.StudentId = studentid;
            course.student.Add(studentdata);
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return 1;

        }*/

        /*public async Task<int> RegisterTeacherForCourse(int teacherid, int courseid)
        {
            var course = await _context.Courses.FindAsync(courseid);
            if (course == null)
                return 0;

            if (course.teacher != null)
                return -2;

            var teacherdata = await _context.Teachers.FindAsync(teacherid);
            if (teacherdata == null)
                return -1;

            course.teacher = teacherdata;
            await _context.SaveChangesAsync();

            return 1;
        }*/

        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var result = await _context.Courses.FindAsync(id);
            return result;
        }

    }
}
