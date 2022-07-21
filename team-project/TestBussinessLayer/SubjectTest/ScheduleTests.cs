namespace TestBussinessLayer.SubjectTest
{
    using BusinessLayer;
    using Models;
    using Models.Exceptions;
    using Xunit;

    public class ScheduleTests : IClassFixture<ScheduleValidator>
    {
        private readonly ScheduleValidator _service;

        public ScheduleTests(ScheduleValidator service)
        {
            _service = service;
        }

        [Fact]
        public void TestScheduleDay()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "L";
            schedule.StartTime = default(DateTime);
            schedule.EndTime = default(DateTime);
            Assert.Throws<subjectExeption>(() => _service.ValidateSchedule(schedule));
        }

        [Fact]
        public void TestScheduleDayEmpty()
        {
            Schedule schedule = new Schedule();
            schedule.Day = " ";
            schedule.StartTime = default(DateTime);
            schedule.EndTime = default(DateTime);
            Assert.Throws<subjectExeption>(() => _service.ValidateSchedule(schedule));
        }

        [Fact]
        public void TestScheduleDayLarge()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL";
            schedule.StartTime = default(DateTime);
            schedule.EndTime = default(DateTime);
            Assert.Throws<subjectExeption>(() => _service.ValidateSchedule(schedule));
        }

        [Fact]
        public void TestScheduleBadStartTime()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "Lunes";
            schedule.StartTime = DateTime.Now.AddHours(3);
            schedule.EndTime = DateTime.Now.AddHours(1);
            Assert.Throws<subjectExeption>(() => _service.ValidateSchedule(schedule));
        }

        [Fact]
        public void TestScheduleBadStartTimeNull()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "Lunes";
            schedule.StartTime = null;
            schedule.EndTime = DateTime.Now.AddHours(1);
            Assert.Throws<subjectExeption>(() => _service.ValidateSchedule(schedule));
        }

        [Fact]
        public void TestScheduleBadEndTime()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "Lunes";
            schedule.StartTime = new DateTime(2022, 4, 28, 3, 0, 0);
            schedule.EndTime = new DateTime(2022, 4, 28, 2, 0, 0);
            Assert.Throws<subjectExeption>(() => _service.ValidateSchedule(schedule));
        }

        [Fact]
        public void TestScheduleBadEndTimeNull()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "Lunes";
            schedule.StartTime = new DateTime(2022, 4, 28, 3, 0, 0);
            schedule.EndTime = null;
            Assert.Throws<subjectExeption>(() => _service.ValidateSchedule(schedule));
        }
    }
}
