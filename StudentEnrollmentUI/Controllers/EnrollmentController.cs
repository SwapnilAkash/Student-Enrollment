using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentUI.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        public EnrollmentController(IConfiguration config)
        {
            _configuration = config;
            baseUrl = _configuration["BaseUrl"];
        }
        public IActionResult Index()
        {
            List<Enrollment> enrollmentdata = null;
            using(HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync($"{baseUrl}Enrollment/GetEnrollmentRecords").Result;
                enrollmentdata = JsonConvert.DeserializeObject<List<Enrollment>>(response);
            }
            
            return View(enrollmentdata);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult EnrollStudent(Enrollment enrollment)
        {
            var enrolldata = JsonConvert.SerializeObject(enrollment);
            using(HttpClient httpClient = new HttpClient())
            {
                var stringContent = new StringContent(enrolldata, UnicodeEncoding.UTF8, "application/json");
                var response = httpClient.PostAsync($"{baseUrl}Enrollment/RegisterStudentForCourse", stringContent).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    TempData["Message"] = "Student enrolled successfully";
                else
                    TempData["Message"] = "Something Went Wrong!!";
            }

            return View();

        }

    }
}
