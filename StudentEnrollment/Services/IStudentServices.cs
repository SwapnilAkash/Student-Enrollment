using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Services
{
    public interface IStudentServices
    {
        Task<string> AddStudent(Student student);

        Task<ActionResult<IEnumerable<Student>>> GetStudents();

        Task<ActionResult<Student>> GetStudentById(int id);

        Task<bool> UpdateStudentRecord(Student student);

        Task<bool> DeleteStudentById(int id);


    }
}
