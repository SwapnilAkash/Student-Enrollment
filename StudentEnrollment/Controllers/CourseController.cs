using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Models;
using StudentEnrollment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices course_services;

        public CourseController(ICourseServices service)
        {
            course_services = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            var result = await course_services.AddCourse(course);
            return Ok(result);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> RegisterStudentForCourse(int studentid, int courseid)
        {
            var result = await course_services.RegisterStudentForCourse(studentid, courseid);
            if (result.Equals(0))
                return BadRequest($"No Course with {courseid} exists!!");
            if (result.Equals(-1))
                return BadRequest($"No Student with {studentid} exists!!");
            else
                return Ok($"Student with id {studentid} registered for Course with id {courseid} successfully.");
        }*/

        /*
        [HttpPost]
        public async Task<IActionResult> RegisterTeacherForCourse(int teacherid, int courseid)
        {
            var result = await course_services.RegisterStudentForCourse(teacherid, courseid);
            if (result.Equals(0))
                return BadRequest($"No Course with {courseid} exists!!");
            if (result.Equals(-2))
                return BadRequest($"Teacher is already registered for the Course with id {courseid} !!");
            if (result.Equals(-1))
                return BadRequest($"No Teacher with {teacherid} exists!!");
            else
                return Ok($"Teacher with id {teacherid} registered for Course with id {courseid} successfully.");
        }*/

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var result = await course_services.GetCourses();
            if(result.Value.Count() == 0)
            {
                return BadRequest("No Course Records Found!!");
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var result = await course_services.GetCourseById(id);
            if (result.Value == null)
            {
                return BadRequest($"No Course with id {id} exists!!");
            }

            return Ok(result.Value);
        }


    }
}
