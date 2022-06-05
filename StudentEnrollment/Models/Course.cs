using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Please enter the title of course in maximum 50 characters")]
        [MaxLength(50)]
        public string title { get; set; }

        [Required]
        [DisplayFormat(NullDisplayText = "No grade")]
        public int credits { get; set; }

        public virtual Teacher teacher { get; set; }

    }
}
