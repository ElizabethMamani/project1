namespace TestPresentationLayer
{
    using BusinessLayer.Exceptions;
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Moq;
    using PresentationLayer.Controllers;
    using Xunit;

    public class CoursesControllerTest
    {
        private readonly CoursesController _courseController;
        private readonly Mock<ICourseService> _mock;

        public CoursesControllerTest()
        {
            _mock = new Mock<ICourseService>();
            _courseController = new CoursesController(null, _mock.Object);
        }

        [Fact]
        public void GetAllCourses_ReturnOkContent()
        {
            _mock.Setup(repo => repo.GetAllCourses()).Returns(new List<Course>()); ;
            IActionResult result = _courseController.GetAllCourses();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllCourses_ReturnOk()
        {
            List<Course> courses = new();
            courses.Add(
            new Course()
            {
                CourseName = "Dev 33 - Level 2",
                Description = "Course for developers and QAs.",
                StartDate = new DateTime(2022, 7, 1),
                EndDate = new DateTime(2022, 12, 1),
                ImageId = "URL image",
            });

            courses.Add(
                new Course()
                {
                    CourseName = "Dev 33 - Level 3",
                    Description = "Course for developers and QAs.",
                    StartDate = new DateTime(2022, 6, 30),
                    EndDate = new DateTime(2022, 12, 30),
                    ImageId = "URL image",
                });

            IEnumerable<Course> coursesTest = courses as IEnumerable<Course>;
            _mock.Setup(repo => repo.GetAllCourses()).Returns(coursesTest);
            IActionResult result = _courseController.GetAllCourses();
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void GetCourse_ReturnNotNull()
        {
            
            _mock.Setup(repo => repo.GetCourse(It.IsAny<int>())).Returns(new Course());
            IActionResult result = _courseController.GetCourse(It.IsAny<int>());
            Assert.NotNull(result);
        }

        [Fact]
        public void GetCourse_ReturnOkResult()
        {

            _mock.Setup(repo => repo.GetCourse(It.IsAny<int>())).Returns(new Course());
            IActionResult result = _courseController.GetCourse(It.IsAny<int>());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetCourse_ReturnNullResult()
        {
            Course course = null;
            _mock.Setup(repo => repo.GetCourse(It.IsAny<int>())).Returns(course);
            IActionResult result = _courseController.GetCourse(It.IsAny<int>());
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetCourse_ReturnOk()
        {
            Course course = new ();
            course.CourseName = "Dev 33 - Level 2";
            course.Description = "Course for developers and QAs.";
            course.StartDate = new DateTime(2022, 7, 1);
            course.EndDate = new DateTime(2022, 12, 1);
            course.ImageId = "URL image";

            _mock.Setup(repo => repo.GetCourse(It.IsAny<int>())).Returns(course);
            IActionResult result = _courseController.GetCourse(It.IsAny<int>());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateCourse_ReturnOk()
        {
            Course course = new();
            course.CourseName = "Dev 33 - Level 2";
            course.Description = "Course for developers and QAs.";
            course.StartDate = new DateTime(2022, 7, 1);
            course.EndDate = new DateTime(2022, 12, 1);
            course.ImageId = "URL image";

            _mock.Setup(repo => repo.AddCourse(course)).Returns(course);
            IActionResult result = _courseController.CreateCourse(course);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void CreateCourse_ReturnCourseException()
        {
            Course course = new();

            _mock.Setup(repo => repo.AddCourse(course)).Throws<CourseException>();
            IActionResult result = _courseController.CreateCourse(course);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateCourse_ReturnOkTest()
        {
            _mock.Setup(repo => repo.UpdateCourse(It.IsAny<int>(), new Course())).Returns(new Course());
            IActionResult result = _courseController.UpdateCourse(It.IsAny<int>(), new Course());
            Assert.IsType<OkObjectResult>(result);
        }
    }
}