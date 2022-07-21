namespace BusinessLayerTest
{
    using BusinessLayer.Services;
    using DataAccessLayer.Interfaces;
    using Models;
    using Moq;
    using Xunit;

    public class StudentServiceTest
    {
        private readonly StudentService _studentService;

        private readonly Mock<IDataAccessStudents> _mock;

        public StudentServiceTest()
        {
            _mock = new Mock<IDataAccessStudents>();
            _studentService = new StudentService(_mock.Object);
        }

        [Fact]
        public void GetAllStudentsReturnCorrectTest()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student());
            _mock.Setup(mock => mock.GetAllStudents()).Returns(students);
            var result = _studentService.GetAllStudents();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllStudentsReturnNullTest()
        {
            List<Student> students = null;
            _mock.Setup(mock => mock.GetAllStudents()).Returns(students);
            var result = _studentService.GetAllStudents();
            Assert.Null(result);
        }

        [Fact]
        public void GetStudentReturnCorrectTest()
        {
            Student student = new ()
                                  {
                                      StudentName = "Roberto Vargas",
                                      Country = "Bolivia",
                                      BirthDate = new System.DateTime(2000, 04, 25),
                                      Email = "jual@gmail.com",
                                      ImageId = "perfilPhoto",
                                  };
            List<Student> students = new List<Student>();
            students.Add(student);
            _mock.Setup(mock => mock.GetStudent(It.IsAny<int>())).Returns(student);
            Student result = _studentService.GetStudent(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetStudentReturnExceptionTest()
        {
            Student student = null;
            _mock.Setup(mock => mock.GetStudent(It.IsAny<int>())).Returns(student);
            var result = _studentService.GetStudent(0);
            Assert.Null(result);
        }

        [Fact]
        public void GetAllStudentReturnCorrectTest()
        {
            Student student = new ()
            {
                StudentName = "Roberto Vargas",
                Country = "Bolivia",
                BirthDate = new System.DateTime(2000, 04, 25),
                Email = "jual@gmail.com",
                ImageId = "perfilPhoto",
            };
            List<Student> students = new List<Student>();
            students.Add(student);
            _mock.Setup(mock => mock.GetAllStudents()).Returns(students);
            var result = _studentService.GetAllStudents();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllStudentReturnNullTest()
        {
            List<Student> students = null;
            _mock.Setup(mock => mock.GetAllStudents()).Returns(students);
            var result = _studentService.GetAllStudents();
            Assert.Null(result);
        }

        [Fact]
        public void CreateStudentReturnCorrectTest()
        {
            Student student = new ()
                                  {
                                      StudentName = "thisiswrongs",
                                      Country = "Bolivia",
                                      BirthDate = new System.DateTime(2000, 04, 25),
                                      Email = "jual@gmail.com",
                                      ImageId = "perfilPhoto",
                                  };
            _mock.Setup(mock => mock.CreateStudent(It.IsAny<Student>())).Returns(new Student());
            var result = _studentService.CreateStudent(student);
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateStudentReturnCorrectIdTest()
        {
            Student student = new ()
                                  {
                                      StudentName = "Roberto Vargas",
                                      Country = "Bolivia",
                                      BirthDate = new System.DateTime(2000, 04, 25),
                                      Email = "jual@gmail.com",
                                      ImageId = "perfilPhoto",
                                  };
            _mock.Setup(mock => mock.CreateStudent(It.IsAny<Student>())).Returns(new Student());
            var result = _studentService.CreateStudent(student);
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateRelationWithCourseCorrectTest()
        {
            Student student = new ()
            {
                StudentId = 1,
                CourseId = 0,
                StudentName = "Roberto Vargas",
                Country = "Bolivia",
                BirthDate = new System.DateTime(2000, 04, 25),
                Email = "jual@gmail.com",
                ImageId = "perfilPhoto",
            };
            _mock.Setup(mock => mock.ExistsIdCoursesInCourses(It.IsAny<int>())).Returns(true);
            _mock.Setup(mock => mock.GetStudent(It.IsAny<int>())).Returns(student);
            _mock.Setup(mock => mock.CreateRelationWithCourse(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            _mock.Setup(mock => mock.GetStudent(It.IsAny<int>())).Returns(student);
            var result = _studentService.CreateRelationWithCourse(0, 1);
            Assert.IsType<Student>(result);
        }

        [Fact]
        public void CreateRelationWithCourseErrorCourseIdTest()
        {
            Student student = new ();
            _mock.Setup(mock => mock.ExistsIdCoursesInCourses(It.IsAny<int>())).Returns(true);
            _mock.Setup(mock => mock.GetStudent(It.IsAny<int>())).Returns(student);
            _mock.Setup(mock => mock.CreateRelationWithCourse(It.IsAny<int>(), It.IsAny<int>())).Returns(0);
            var result = _studentService.CreateRelationWithCourse(0, 1);
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateRelationWithCourseErrorIdTest()
        {
            Student student;
            _mock.Setup(mock => mock.ExistsIdCoursesInCourses(It.IsAny<int>())).Returns(true);
            _mock.Setup(mock => mock.GetStudent(It.IsAny<int>())).Returns(new Student());
            _mock.Setup(mock => mock.CreateRelationWithCourse(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            _mock.Setup(mock => mock.GetStudent(It.IsAny<int>())).Returns(new Student());
            var result = _studentService.CreateRelationWithCourse(0, 1);
            Assert.NotNull(result);
        }
    }
}