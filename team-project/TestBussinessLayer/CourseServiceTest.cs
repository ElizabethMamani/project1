namespace TestBussinessLayer
{
    using BusinessLayer.Exceptions;
    using BusinessLayer.Services;
    using DataAccessLayer.Interfaces;
    using Models;
    using Moq;
    using Xunit;

    public class CourseServiceTest
    {
        private readonly CourseService _courseService;
        private readonly Mock<IDataAccessCourses> _mock;

        public CourseServiceTest()
        {
            _mock = new Mock<IDataAccessCourses>();
            _courseService = new CourseService(_mock.Object);
        }

        [Fact]
        public void GetAllCourses_ReturnCoursesNotFoundException()
        {
            IEnumerable<Course> emptyCourses = Enumerable.Empty<Course>();
            _mock.Setup((repo) => repo.GetAllCourses()).Throws<CoursesNotFoundException>();
            Assert.Throws<CoursesNotFoundException>(() => _courseService.GetAllCourses());
        }

        [Fact]
        public void GetAllCourses_ReturnCourses()
        {
            List<Course> courses = new ();
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

            _mock.Setup((repo) => repo.GetAllCourses()).Returns(coursesTest);
            Assert.NotNull(_courseService.GetAllCourses());
        }

        [Fact]
        public void GetAllCourses_ReturNull()
        {
            List<Course> courses = null;
            _mock.Setup((repo) => repo.GetAllCourses()).Returns(courses);
            Assert.Null(_courseService.GetAllCourses());
        }

        [Fact]
        public void GetCourse_ReturnCourseNotFoundException()
        {
            _mock.Setup((repo) => repo.GetCourse(It.IsAny<int>())).Throws<CourseNotFoundException>();
            Assert.Throws<CourseNotFoundException>(() => _courseService.GetCourse(It.IsAny<int>()));
        }

        [Fact]
        public void GetCourse_ReturnCourse()
        {
            Course courseTest = new Course();
            courseTest.CourseName = "Dev 33 - Level 2";
            courseTest.Description = "Course for developers and QAs.";
            courseTest.StartDate = new DateTime(2022, 7, 1);
            courseTest.EndDate = new DateTime(2022, 12, 1);
            courseTest.ImageId = "URL image";

            _mock.Setup((repo) => repo.GetCourse(It.IsAny<int>())).Returns(courseTest);
            Assert.NotNull(_courseService.GetCourse(It.IsAny<int>()));
        }

        [Fact]
        public void GetCourse_ReturnCourseNull()
        {
            Course courseTest = null;
            _mock.Setup((repo) => repo.GetCourse(It.IsAny<int>())).Returns(courseTest);
            Assert.Null(_courseService.GetCourse(It.IsAny<int>()));
        }

        [Fact]
        public void AddCourse_SuccessfulReturnCourse()
        {
            Course courseTest = new Course();
            courseTest.CourseName = "Dev33-Level2";
            courseTest.Description = "Course for developers and QAs.";
            courseTest.StartDate = DateTime.Now.AddDays(1);
            courseTest.EndDate = DateTime.Now.AddDays(2);
            courseTest.ImageId = "URL image";

            _mock.Setup((repo) => repo.AddCourse(courseTest)).Returns(courseTest);
            Assert.NotNull(_courseService.AddCourse(courseTest));
        }

        [Fact]
        public void AddCourse_FailReturnCourseException()
        {
            Course courseTest = new Course();
            _mock.Setup((repo) => repo.AddCourse(courseTest)).Throws<CourseException>();
            Assert.Throws<CourseException>(() => _courseService.AddCourse(courseTest));
        }

        [Fact]
        public void UpdateCourse_ReturnCourseNotFoundException()
        {
            Course courseTest = new Course();
            courseTest.CourseName = "Dev 33 - Level 2";
            courseTest.Description = "Course for developers and QAs.";
            courseTest.StartDate = new DateTime(2022, 7, 1);
            courseTest.EndDate = new DateTime(2022, 12, 1);
            courseTest.ImageId = "URL image";
            _mock.Setup((repo) => repo.UpdateCourse(It.IsAny<int>(), courseTest)).Throws<CourseNotFoundException>();
            Assert.Throws<CourseNotFoundException>(() => _courseService.UpdateCourse(It.IsAny<int>(), courseTest));
        }

        [Fact]
        public void DeleteCourse_ReturnCourseNotFoundException()
        {
            _mock.Setup((repo) => repo.DeleteCourse(It.IsAny<int>())).Throws<CourseNotFoundException>();
            Assert.Throws<CourseNotFoundException>(() => _courseService.DeleteCourse(It.IsAny<int>()));
        }
    }
}