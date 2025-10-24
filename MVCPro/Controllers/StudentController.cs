using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCPro.Models;
using System.Linq;
using MVCPro.Services;

namespace MVCPro.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _service;

        public StudentController(ILogger<StudentController> logger, IStudentService service)
        {
            _logger = logger;
            _service = service;
        }

        // Index page - shows all students
        [Route("Student")]
        [Route("Student/Index")]
        public IActionResult Index([FromQuery] int id = 0, [FromQuery] bool isStudentExist = false)
        {
            ViewBag.id = id;
            ViewBag.StudentExist = isStudentExist;

            // Get the list of students from the service
            var students = _service.GetStudentData();
            ViewBag.ServiceData = students;

            return View("Index");
        }

        // GET: Create student form
        [Route("Student/Create")]
        public IActionResult Create()
        {
            return View("StudentEdit");
        }

        // POST: Submit new student
        [HttpPost]
        [Route("Student/Submit")]
        public IActionResult Submit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                // Assign a new ID
                var students = _service.GetStudentData();
                student.StudentId = students.Count > 0
                    ? students.Max(s => s.StudentId) + 1
                    : 1;

                // Add student using the service
                _service.AddStudent(student);

                // Redirect to Index page to show the newly added student
                return RedirectToAction("Index", new { id = student.StudentId, isStudentExist = true });
            }

            return View("StudentEdit", student);
        }

        // GET /Student/GetStudents
        [Route("Student/GetStudents")]
        public IActionResult GetStudents()
        {
            var students = _service.GetStudentData();
            return View("GetStudents", students);
        }

        // GET: Success page
        [Route("Student/Success")]
        public IActionResult Success(int id)
        {
            var student = _service.GetStudentData().FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return RedirectToAction("Index");

            return View("Success", student);
        }
    }
}