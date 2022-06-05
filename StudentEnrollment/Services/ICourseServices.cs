using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Services
{
    public interface ICourseServices
    {
        Task<string> AddCourse(Course course);

        //Task<int> RegisterStudentForCourse(int studentid, int courseid);

        //Task<int> RegisterTeacherForCourse(int teacherid, int courseid);

        Task<ActionResult<IEnumerable<Course>>> GetCourses();

        Task<ActionResult<Course>> GetCourseById(int id);


    }
}
