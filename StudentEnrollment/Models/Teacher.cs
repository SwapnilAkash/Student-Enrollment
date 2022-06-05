using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }

        [Required(ErrorMessage = "Please enter the name of maximum 50 characters")]
        [MaxLength(50)]
        public string name { get; set; }

        public int? age { get; set; }

        public int CourseId { get; set; }
        public virtual Course course { get; set; }

    }
}
