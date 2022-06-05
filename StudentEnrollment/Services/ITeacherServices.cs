using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Services
{
    public interface ITeacherServices
    {
        Task<string> AddTeacher(Teacher teacher);

        Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Teacher>>> GetTeachers();

        Task<ActionResult<Teacher>> GetTeacherById(int id);

        Task<bool> UpdateTeacherRecord(Teacher teacher);

        Task<bool> DeleteTeacherById(int id);
    }
}
