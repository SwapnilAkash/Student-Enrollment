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
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _student_services;

        public StudentController(IStudentServices service)
        {
            _student_services = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _student_services.GetStudents();
            if (result.Value.Count() == 0)
                return BadRequest("No Student Record Found!!");

            return Ok(result.Value);
        }

        [HttpGet]

        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var result = await _student_services.GetStudentById(id);
            if (result.Value == null)
                return BadRequest($"No Student with id {id} exists!!");

            return Ok(result.Value);
        }

        [HttpPost]

        public async Task<IActionResult> AddStudent(Student student)
        {
            var result =  await _student_services.AddStudent(student);
            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateStudentRecord(Student student)
        {
            var result = await _student_services.UpdateStudentRecord(student);
            if (!result)
                return BadRequest($"No Student with id {student.StudentID} exists!!");

            return Ok($"Student with id {student.StudentID} updated successfully");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteStudentById(int id)
        {
            var result = await _student_services.DeleteStudentById(id);
            if (!result)
                return BadRequest($"No Student with id {id} exists!!");

            return Ok($"Student with id {id} deleted succesfully.");
        }

    }
}
