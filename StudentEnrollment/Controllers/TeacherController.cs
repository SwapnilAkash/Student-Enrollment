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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherServices teacher_services;

        public TeacherController(ITeacherServices service)
        {
            teacher_services = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher teacher)
        {
            var result = await teacher_services.AddTeacher(teacher);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var result = await teacher_services.GetTeachers();
            if (result.Value.Count() == 0)
                return BadRequest($"No Teacher Records Found!!");

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var result = await teacher_services.GetTeacherById(id);
            if (result.Value == null)
                return BadRequest($"No Teacher with id {id} exists!!");
            
            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacherRecord(Teacher teacher)
        {
            var result = await teacher_services.UpdateTeacherRecord(teacher);
            if (!result)
                return BadRequest($"No Teacher with id {teacher.TeacherID} exists!!");

            return Ok($"Teacher with id {teacher.TeacherID} updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacherById(int id)
        {
            var result = await teacher_services.DeleteTeacherById(id);
            if (result)
                return BadRequest($"No Teacher with id {id} exists!!");

            return Ok($"Teacher with id {id} deleted successfully");
        }
    }
}
