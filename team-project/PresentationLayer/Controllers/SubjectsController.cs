// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    using BusinessLayer;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Exceptions;
    using PresentationLayer.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase, ISubjectController
    {
        private IServiceSubject subjectService;

        private readonly ILogger<SubjectsController> logger;

        public SubjectsController(ILogger<SubjectsController> logger, IServiceSubject subjectService)
        {
            this.logger = logger;
            this.subjectService = subjectService;
        }

        // GET: api/<SubjectController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<Subject>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
                IEnumerable<Subject> subject = this.subjectService.GetAllSubjects();
                if (subject.ToList().Count > 0)
                {
                    return this.Ok(subject);
                }
                else
                {
                    return this.NoContent();
                }
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get(int id)
        {
                Subject? result = this.subjectService.GetSubject(id);
                if (result is null)
                {
                    return this.NotFound("Not exist this ID " +id);
                }

                return this.Ok(result);
        }

        [HttpGet("Course/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetByIdCourse(int id)
        {
            List<Subject> result = this.subjectService.GetSubjectsByIdCourse(id);
            if (result.Count == 0)
            {
                return this.NotFound("Not exist this ID of Course: " + id + " in the list of Subjects");
            }

            return this.Ok(result);
        }

        // POST api/<SubjectController>
        [HttpPost]
        [ProducesResponseType(typeof(Subject), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] Subject value)
        {
            try
            {
                Subject? result = this.subjectService.SaveSubject(value);
                if (result is null)
                {
                    return this.BadRequest("Not can be Create the Subject");
                }

                return this.Created(nameof(this.Post), result);
            }
            catch (ApiException ex)
            {
                return this.StatusCode(ex.ErrorCode, ex.Message);
            }
            catch (ValidationException ex)
            {
                return this.BadRequest(ex.ErrorMessage);
            }
        }
    }
}
