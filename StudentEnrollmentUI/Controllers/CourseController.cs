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
    public class CourseController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        public CourseController(IConfiguration config)
        {
            _configuration = config;
             baseUrl = _configuration["BaseUrl"];
        }
        public IActionResult Index()
        {
            List<Course> coursedata = null;
            using (HttpClient httpclient = new HttpClient())
            {
                var response = httpclient.GetStringAsync($"{baseUrl}Course/GetCourses").Result;
                coursedata = JsonConvert.DeserializeObject<List<Course>>(response);
            }
            return View(coursedata);
        }

        public IActionResult Details(int courseid)
        {
            Course coursedata = null;
            using (HttpClient httpclient = new HttpClient())
            {
                var response = httpclient.GetStringAsync($"{baseUrl}Course/GetCourseById?id={courseid}").Result;
                coursedata = JsonConvert.DeserializeObject<Course>(response);
            }
            return View(coursedata);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddNewCourse(Course course)
        {
            var coursedata = JsonConvert.SerializeObject(course);
            using(HttpClient httpClient = new HttpClient())
            {
                var stringContent = new StringContent(coursedata, UnicodeEncoding.UTF8, "application/json");
                var response = httpClient.PostAsync($"{baseUrl}Course/AddCourse", stringContent).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    TempData["Message"] = "Course Added Successfully";
                else
                    TempData["Message"] = "Something Went Wrong";
            }

            return View();
        }
    }
}
