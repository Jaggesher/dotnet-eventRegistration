using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_eventRegistration.Models;
using dotnet_eventRegistration.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_eventRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentViewModel student )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentService.addStudent(student);
            if (result) return Redirect("Index");

            return BadRequest(new { error = "Could not register" });

            //return Json(student);
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var model = _studentService.getAll();
            
            return Json(model);
        }
    }
}
