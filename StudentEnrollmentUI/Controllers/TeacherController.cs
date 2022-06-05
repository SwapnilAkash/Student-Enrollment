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
    public class TeacherController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        public TeacherController(IConfiguration config)
        {
            _configuration = config;
            baseUrl = _configuration["BaseUrl"];
        }
        public IActionResult Index()
        {
            List<Teacher> teacherdata = null;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync($"{baseUrl}Teacher/GetTeachers").Result;
                teacherdata = JsonConvert.DeserializeObject<List<Teacher>>(response);
            }
            return View(teacherdata);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddNewTeacher(Teacher teacher)
        {
            var teacherdata = JsonConvert.SerializeObject(teacher);
            using(HttpClient httpClient = new HttpClient())
            {
                var stringContent = new StringContent(teacherdata, UnicodeEncoding.UTF8, "application/json");
                var response = httpClient.PostAsync($"{baseUrl}Teacher/AddTeacher", stringContent).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    TempData["Message"] = "Teacher Added Successfully";
                else
                   TempData["Message"] = "Something Went Wrong!!";
            }

            return View();
        }

        public IActionResult Edit(int teacherid)
        {
            TempData["TeacherId"] = teacherid;
            return View();
        }

        public IActionResult UpdateTeacher(Teacher teacher)
        {
            var teacherdata = JsonConvert.SerializeObject(teacher);
            using (HttpClient httpclient = new HttpClient())
            {
                var stringContent = new StringContent(teacherdata, UnicodeEncoding.UTF8, "application/json");
                var response = httpclient.PutAsync($"{baseUrl}Teacher/UpdateTeacherRecord", stringContent).Result;
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    TempData["Message"] = "Record Updated Successfully";
                else
                    TempData["Message"] = "Something Went Wrong !!";
            }

            return View();
        }

        public IActionResult Details(int teacherid)
        {
            Teacher teacherdata = null;
            using (HttpClient httpclient = new HttpClient())
            {
                var response = httpclient.GetStringAsync($"{baseUrl}Teacher/GetTeacherById?id={teacherid}").Result;
                teacherdata = JsonConvert.DeserializeObject<Teacher>(response);
            }
            return View(teacherdata);
        }

        public IActionResult Delete(int teacherid)
        {
            using(HttpClient httpclient = new HttpClient())
            {
                var response = httpclient.DeleteAsync($"{baseUrl}Teacher/DeleteTeacherById?id={teacherid}").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    TempData["Message"] = "Record Deleted Successfully";
                else
                    TempData["Message"] = "Something Went Wrong !!";
            }

            return View();
        }
    }
}
