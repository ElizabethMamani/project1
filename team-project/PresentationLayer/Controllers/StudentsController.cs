

namespace PresentationLayer.Controllers
{
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        private readonly IStudentService studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            IEnumerable<Student> result = this.studentService.GetAllStudents();
            if (result is null || !result.Any())
            {
                return this.NoContent();
            }

            return this.Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            Student result = this.studentService.GetStudent(id);
            if (result is null)
            {
                return this.NotFound("The student with that id does not exist");
            }

            return this.Ok(this.studentService.GetStudent(id));
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            try
            {
                return this.Ok(this.studentService.CreateStudent(student));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPut("{studentId},{courseId}")]

        public IActionResult CreateRelationWithCourse(int studentId, int courseId)
        {
            try
            {
                return this.Ok(this.studentService.CreateRelationWithCourse(studentId, courseId));
            }
            catch (Exception ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}