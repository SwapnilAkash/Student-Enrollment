using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Services
{
    public class StudentServices : IStudentServices
    {

        private readonly StudentAPIContext _context;

        public StudentServices(StudentAPIContext context)
        {
            _context = context;
        }

        public async Task<string> AddStudent(Student student)
        {
            /*var entry = _context.Students.AddAsync(new Student()
            {
                age = student.age,
                name = student.name,
                gender = student.gender
            });*/

            var entry = _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return $"Student created with id {student.StudentID}";

             
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var result = await _context.Students.FindAsync(id);
            return result;
        }

        public async Task<bool> UpdateStudentRecord(Student student)
        {
            /*var update_student = new Student()
            {
                StudentID = student.StudentID,
                name = student.name,
                age = student.age,
                gender = student.gender
            };*/

            var update_stu = _context.Students.Any(x => x.StudentID == student.StudentID);
            if (update_stu == false)
                return false;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool> DeleteStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        
        
    }
}
