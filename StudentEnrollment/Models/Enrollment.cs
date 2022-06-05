using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Course course { get; set; }
        public Student student { get; set; }
    }
}
