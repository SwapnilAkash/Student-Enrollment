using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter the name of maximum 50 characters")]
        [MaxLength(50)]
        public string name { get; set; }

        public int? age { get; set; }

        public string gender { get; set; }

    }
}
