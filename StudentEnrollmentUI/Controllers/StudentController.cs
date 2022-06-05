using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StudentController> _logger;
        private readonly string baseURL;
        public StudentController(IConfiguration config, ILogger<StudentController> logger)
        {
            _configuration = config;
            _logger = logger;
            baseURL = _configuration["BaseUrl"];
        }
        public IActionResult Index()
        {
            List<Student> studentsdata = null;
            using(HttpClient httpclient = new HttpClient())
            {
                var response = httpclient.GetStringAsync($"{baseURL}Student/GetStudents").Result;
                studentsdata = JsonConvert.DeserializeObject<List<Student>>(response);
            }
            return View(studentsdata);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddStudentRecord(Student student)
        {
            _logger.LogInformation("Starting Request");
            try
            {
                HttpResponseMessage response = null;
                //StringContent stringContent = null;
                var studentdata = JsonConvert.SerializeObject(student);
                using (HttpClient httpclient = new HttpClient())
                {
                    var stringContent = new StringContent(studentdata, UnicodeEncoding.UTF8, "application/json");
                    response = httpclient.PostAsync($"{baseURL}Student/AddStudent", stringContent).Result;
                }
                return View();
              
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return BadRequest("Something Went Wrong !!");
            }
        }

        public IActionResult Edit(int studentid)
        {
            ViewData["StudentId"] = studentid;
            return View();
        }

        public IActionResult UpdateStudent(Student student)
        {
            var studentdata = JsonConvert.SerializeObject(student);
            using (HttpClient httpclient = new HttpClient())
            {
                var stringContent = new StringContent(studentdata, UnicodeEncoding.UTF8, "application/json");
                var response = httpclient.PutAsync($"{baseURL}Student/UpdateStudentRecord", stringContent).Result;
            }

            return View();
        }

        public IActionResult Details(int studentid)
        {
            Student studentdata = null;
            using (HttpClient httpclient = new HttpClient())
            {
                var response = httpclient.GetStringAsync($"{baseURL}Student/GetStudentById?id={studentid}").Result;
                studentdata = JsonConvert.DeserializeObject<Student>(response);
            }
            return View(studentdata);
        }

        public IActionResult Delete(int studentid)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                var response = httpclient.DeleteAsync($"{baseURL}Student/DeleteStudentById?id={studentid}").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    TempData["Message"] = "Record Deleted Successfully";
                else
                    TempData["Message"] = "Something Went Wrong !!";
            }

            return View();
        }
    }
}
