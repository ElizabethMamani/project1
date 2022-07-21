

namespace TestPresentationLayer
{

    using BusinessLayer.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    using Models;

    using Moq;

    using PresentationLayer.Controllers;
    using Xunit;

    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> moq;

        private readonly StudentsController studentsController;

        public StudentControllerTest()
        {
            this.moq = new Mock<IStudentService>();
            this.studentsController = new StudentsController(null, this.moq.Object);
        }

        [Fact]
        public void GetStudentReturnOkTest() 
        {
            this.moq.Setup(moq => moq.GetStudent(It.IsAny<int>())).Returns(new Student());
            IActionResult result = this.studentsController.GetStudent(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]

        public void GetStudentReturnNotFoundTest()
        {
            Student student= null;
            this.moq.Setup(moq => moq.GetStudent(It.IsAny<int>())).Returns(student);
            var result = this.studentsController.GetStudent(0);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetAllStudentReturnNoContentTest()
        {
            var students = new List<Student>();
            this.moq.Setup(moq => moq.GetAllStudents()).Returns(new List<Student>());
            var result = this.studentsController.GetAllStudents();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void CreateStudentReturnNoContentTest()
        {
            this.moq.Setup(moq => moq.CreateStudent(new Student())).Returns(new Student());
            var result = this.studentsController.GetAllStudents();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void CreateStudentReturnBadRequestTest()
        {
            this.moq.Setup(moq => moq.CreateStudent(It.IsAny<Student>())).Throws<Exception>();
            var result = this.studentsController.CreateStudent(new Student());
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateRelationWithCourseOkTest()
        {
            this.moq.Setup(moq => moq.CreateRelationWithCourse(It.IsAny<int>(), It.IsAny<int>())).Returns(new Student());
            var result = this.studentsController.CreateRelationWithCourse(1, 1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateRelationWithCourseNotFoundTest()
        {
            this.moq.Setup(moq => moq.CreateRelationWithCourse(It.IsAny<int>(), It.IsAny<int>())).Throws<Exception>();
            var result = this.studentsController.CreateRelationWithCourse(1, 1);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
