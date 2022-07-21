// <copyright file="CourseController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationLayer.Controllers
{
    using BusinessLayer.Exceptions;
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;

        private readonly ICourseService courseService;

        public CoursesController(ILogger<CoursesController> logger, ICourseService courseService)
        {
            _logger = logger;
            this.courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        public IActionResult GetAllCourses()
        {

                IEnumerable<Course> courses = courseService.GetAllCourses();
                if (courses is not null || !courses.Any())
                {
                    return this.Ok(courses);
                }

                return this.NoContent();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        public IActionResult GetCourse(int id)
        {
            Course result = this.courseService.GetCourse(id);
            if (result is not null)
            {
                return this.Ok(result);
            }
            return this.NotFound("The course id doesn't exist.");
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            try
            {
                Course? response = this.courseService.AddCourse(course);
                return this.Created(nameof(this.CreateCourse), response);
            }
            catch (CourseException ex)
            {
                return this.BadRequest(ex.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            Course result;
            try
            {
                result = this.courseService.UpdateCourse(id, course);
                return this.Ok(result);
            }
            catch (CourseException ex)
            {
                return this.BadRequest(ex.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                return this.Ok(this.courseService.DeleteCourse(id));
            }
            catch (CourseException ex)
            {
                return this.NotFound(ex.ErrorMessage);
            }
        }
    }
}
