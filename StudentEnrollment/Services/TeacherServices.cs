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
    public class TeacherServices : ITeacherServices
    {
        private readonly StudentAPIContext _context;

        public TeacherServices(StudentAPIContext context)
        {
            _context = context;
        }

        public async Task<string> AddTeacher(Teacher teacher)
        {
            var entry = await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return $"Teacher with id {teacher.TeacherID} created successfully.";
        }

        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<bool> UpdateTeacherRecord(Teacher teacher)
        {
            var update_teacher = _context.Teachers.Any(x => x.TeacherID == teacher.TeacherID);
            if (update_teacher == false)
                return false;

            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTeacherById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}
