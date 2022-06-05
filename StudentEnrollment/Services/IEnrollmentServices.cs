using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Services
{
    public interface IEnrollmentServices
    {
        Task<int> RegisterStudentForCourse(Enrollment enrollment);

        Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollmentRecords();

        Task<dynamic> GetEnrollmentRecordsByStudentId(int studentid);
    }
}
