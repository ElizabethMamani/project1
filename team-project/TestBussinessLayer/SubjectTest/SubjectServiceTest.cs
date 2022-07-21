namespace TestBussinessLayer
{
    using BusinessLayer;
    using DataAccessLayer.Interfaces;
    using Models;
    using Moq;
    using Xunit;

    public class SubjectServiceTest
    {
        private readonly SubjectService _service;
        private readonly Mock<IDataAccessSubjects> _mock;

        public SubjectServiceTest()
        {
            _mock = new Mock<IDataAccessSubjects>();
            _service = new SubjectService(_mock.Object);
        }

        [Fact]
        public void GetSubjectsTest()
        {
            _mock.Setup((repo) => repo.GetAll()).Returns(new List<Subject>());
            IEnumerable<Subject> results = _service.GetAllSubjects();
            Assert.NotNull(results);
        }

        [Fact]
        public void GetSubjectsNullTest()
        {
            List<Subject> res = null;
            _mock.Setup((repo) => repo.GetAll()).Returns(res);
            IEnumerable<Subject> results = _service.GetAllSubjects();
            Assert.Null(results);
        }

        [Fact]
        public void GetSubjectsByIdTest()
        {
            _mock.Setup((repo) => repo.GetSubject(It.IsAny<int>())).Returns(new Subject());
            Subject result = _service.GetSubject(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetSubjectsByIdNullTest()
        {
            Subject res = null;
            _mock.Setup((repo) => repo.GetSubject(It.IsAny<int>())).Returns(res);
            Subject result = _service.GetSubject(1);
            Assert.Null(result);
        }

        [Fact]
        public void GetSubjectsByIdOfCourseTest()
        {
            _mock.Setup((repo) => repo.GetListSubjectByIDCourse(It.IsAny<int>())).Returns(new List<Subject>());
            List<Subject> result = _service.GetSubjectsByIdCourse(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetSubjectsByIdOfCourseNullResultTest()
        {
            List<Subject> results = null;
            _mock.Setup((repo) => repo.GetListSubjectByIDCourse(It.IsAny<int>())).Returns(results);
            List<Subject> res = _service.GetSubjectsByIdCourse(1);
            Assert.Null(res);
        }

        [Fact]
        public void SaveSubjectTest()
        {
            Subject subject = new Subject();
            subject.CourseId = 3;
            subject.SubjectId = 170;
            subject.SubjectName = "aaaaaaa";
            subject.StartDate = DateTime.Now.AddDays(1);
            subject.Instructorname = "JuanMarceloLivos";
            subject.ImageId = "./aaaaaaaa";
            Schedule schedule = new Schedule();
            schedule.SubjectId = 170;
            schedule.ScheduleId = 1;
            schedule.Day = "Martes";
            schedule.StartTime = DateTime.Now.AddDays(1);
            schedule.EndTime = DateTime.Now.AddDays(10);
            List<Schedule> schedules = new List<Schedule>();
            schedules.Add(schedule);
            subject.schedules = schedules;

            _mock.Setup((repo) => repo.ExistsIdCourses(It.IsAny<int>())).Returns(true);

            _mock.Setup((repo) => repo.Save(It.IsAny<Subject>())).Returns(new Subject());
            Subject result = _service.SaveSubject(subject);
            Assert.NotNull(result);
        }

        // [Fact]
        // public void SaveSubjectReturnNullTest()
        // {
        //    Subject res = null;
        //    _mock.Setup((repo) => repo.ExistsIdCourses(It.IsAny<int>())).Returns(false);

        // _mock.Setup((repo) => repo.Save(It.IsAny<Subject>())).Returns(res);
        //    Subject result = _service.SaveSubject(It.IsAny<Subject>());
        //    Assert.Null(result);
        // }
    }
}