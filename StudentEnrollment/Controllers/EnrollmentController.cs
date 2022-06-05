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
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentServices _enrollment_service;
        public EnrollmentController(IEnrollmentServices service)
        {
            _enrollment_service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudentForCourse(Enrollment enrollment)
        {
            var result = await _enrollment_service.RegisterStudentForCourse(enrollment);
            if (result.Equals(0))
                return BadRequest($"No Course with id {enrollment.CourseId} exists!!");

            if (result.Equals(-1))
                return BadRequest($"No Student with id {enrollment.StudentId} exists!!");

            return Ok($"Student with id {enrollment.StudentId} registered for Course with id {enrollment.CourseId} successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollmentRecords()
        {
            var result = await _enrollment_service.GetEnrollmentRecords();
            if (result.Value.Count() == 0)
                return BadRequest("No Enrollment Records Found!!");

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollmentRecordsByStudentId(int studentid)
        {
            var result = await _enrollment_service.GetEnrollmentRecordsByStudentId(studentid);

            if (result.Count == 0)
                return BadRequest($"No Record Found!!");

            return Ok(result);
        }
    }
}
