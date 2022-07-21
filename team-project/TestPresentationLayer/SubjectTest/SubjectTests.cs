using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using PresentationLayer.Controllers;
using System.Collections.Generic;
using Xunit;

namespace TestPresentationLayer.SubjectTest
{
    public class SubjectTests
    {
        Mock<IServiceSubject> moq;
        SubjectsController controller;
        public SubjectTests() {
            moq = new Mock<IServiceSubject> ();
            controller = new SubjectsController(null, moq.Object);
        }

        [Fact]
        public void GetAllSubject_NoContentResultTest()
        {
            moq.Setup(moq => moq.GetAllSubjects()).Returns(new List<Subject>());
            IActionResult result = controller.GetAll();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetAllSubject_ReturnOkTest()
        {
            List<Subject> subjects = new List<Subject>();
            Subject subject = new Subject();
            subjects.Add(subject);
            moq.Setup(moq => moq.GetAllSubjects()).Returns(subjects);
            IActionResult result = controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnOkTest() {
            moq.Setup(moq => moq.GetSubject(It.IsAny<int>())).Returns(new Subject());
            IActionResult result = controller.Get(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_NoContentTest()
        {
            Subject subject = null;
            moq.Setup(moq => moq.GetSubject(It.IsAny<int>())).Returns(subject);
            IActionResult result = controller.Get(111);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetByIdCourse_Test()
        {
            Subject subject = new Subject();

            subject.CourseId = 1;
            subject.SubjectId = 1;
            subject.SubjectName = "DevOps";
            subject.Instructorname = "JuanMarceloLivos";
            subject.StartDate = new DateTime(2022, 6, 28, 2, 0, 0);
            subject.ImageId = "./";
            Schedule schedule = new Schedule();
            schedule.SubjectId = 1;
            schedule.ScheduleId = 1;
            schedule.Day = "Martes";
            schedule.StartTime = new DateTime();
            schedule.EndTime = new DateTime();
            List<Schedule> schedules = new List<Schedule>();
            schedules.Add(schedule);
            subject.schedules = schedules;

            List<Subject> subjects = new List<Subject>();
            subjects.Add(subject);

            moq.Setup(moq => moq.GetSubjectsByIdCourse(It.IsAny<int>())).Returns(subjects);
            IActionResult result = controller.GetByIdCourse(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetSubjectsByIDCourseOk_Test()
        {
            Subject subject = new Subject();

            subject.CourseId = 3;
            subject.SubjectId = 1;
            subject.SubjectName = "DevOps";
            subject.Instructorname = "JuanMarceloLivos";
            subject.StartDate = new DateTime(2022, 6, 28, 2, 0, 0);
            subject.ImageId = "./";
            Schedule schedule = new Schedule();
            schedule.SubjectId = 1;
            schedule.ScheduleId = 1;
            schedule.Day = "Martes";
            schedule.StartTime = new DateTime();
            schedule.EndTime = new DateTime();
            List<Schedule> schedules = new List<Schedule>();
            schedules.Add(schedule);
            subject.schedules = schedules;

            List<Subject> subjects = new List<Subject>();
            subjects.Add(subject);

            moq.Setup(moq => moq.GetSubjectsByIdCourse(3)).Returns(subjects);
            IActionResult result = controller.GetByIdCourse(3);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void PostBadRequestTest()
        {
            Subject subject = new Subject();

            subject.CourseId = 3;
            subject.SubjectId = 1;
            subject.SubjectName = "DevOps";
            subject.Instructorname = "JuanMarceloLivos";
            subject.StartDate = new DateTime(2022, 7, 28, 2, 0, 0);
            subject.ImageId = "./aaaaaa";
            Schedule schedule = new Schedule();
            schedule.SubjectId = 1;
            schedule.ScheduleId = 1;
            schedule.Day = "Martes";
            schedule.StartTime = new DateTime(2022, 7, 28, 2, 0, 0);
            schedule.EndTime = new DateTime(2022, 7, 28, 3, 0, 0);
            List<Schedule> schedules = new List<Schedule>();
            schedules.Add(schedule);
            subject.schedules = schedules;

            moq.Setup(moq => moq.SaveSubject(new Subject())).Returns(new Subject());
            IActionResult result = controller.Post(subject);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
