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
         private readonly IEmailSender _emailSender;
        public StudentController(IStudentService studentService, IEmailSender emailSender)
        {
            _studentService = studentService;
            _emailSender = emailSender;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(StudentViewModel student )
        {
            if (!ModelState.IsValid)
            {
               return View(student);
            }

            String result = await _studentService.addStudent(student);

            if (result != null){

                await _emailSender.SendEmailAsync(student.Email, "Your Code", "Your Unique Token IS : " + result);

                return RedirectToAction(nameof(Index));

            }

            return BadRequest(new { error = "Could not register" });

            //return Json(student);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await _studentService.getAll();
            AllStudentViewModel Data = new AllStudentViewModel()
            {
                AllStudent = model
            };
            return View(Data);
        }

        public async Task<IActionResult> Show(Guid StudentId)
        {
            Student model = await _studentService.GetStudent(StudentId);
            return View(model);
        }
    }
}
