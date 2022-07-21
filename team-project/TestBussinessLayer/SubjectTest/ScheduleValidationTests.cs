namespace TestBussinessLayer.SubjectTest
{
    using BusinessLayer;
    using FluentValidation.TestHelper;
    using Models;
    using Xunit;

    public class ScheduleValidationTests
    {
        private readonly ScheduleValidator _validator;

        public ScheduleValidationTests()
        {
            _validator = new ScheduleValidator();
        }

        [Fact]
        public void ShouldHaveErrorDayScheduleShort()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "B";
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldHaveValidationErrorFor(x => x.Day);
        }

        [Fact]
        public void ShouldHaveErrorDayScheduleLarge()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "bbbbbbbbbbbbbbbbbbbbbbb";
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldHaveValidationErrorFor(x => x.Day);
        }

        [Fact]
        public void ShouldHaveErrorDayScheduleEmpty()
        {
            Schedule schedule = new Schedule();
            schedule.Day = " ";
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldHaveValidationErrorFor(x => x.Day);
        }

        [Fact]
        public void ShouldDontHaveErrorDaySchedule()
        {
            Schedule schedule = new Schedule();
            schedule.Day = "Lunes";
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldNotHaveValidationErrorFor(x => x.Day);
        }

        [Fact]
        public void ShouldDontHaveErrorDayScheduleEmpty()
        {
            Schedule schedule = new Schedule();
            schedule.Day = " ";
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldHaveValidationErrorFor(x => x.Day);
        }

        [Fact]
        public void ShouldHaveErrorDateEndSchedule()
        {
            Schedule schedule = new Schedule();
            schedule.StartTime = new DateTime(2022, 7, 28, 3, 0, 0);
            schedule.EndTime = new DateTime(2022, 5, 28, 3, 0, 0);
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldHaveValidationErrorFor(x => x.EndTime);
        }

        [Fact]
        public void ShouldHaveErrorDateEndScheduleNull()
        {
            Schedule schedule = new Schedule();
            schedule.StartTime = new DateTime(2022, 7, 28, 3, 0, 0);
            schedule.EndTime = null;
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldHaveValidationErrorFor(x => x.EndTime);
        }

        [Fact]
        public void ShouldNotHaveErrorDateEndSchedule()
        {
            Schedule schedule = new Schedule();
            schedule.StartTime = new DateTime(2023, 7, 28, 3, 0, 0);
            schedule.EndTime = new DateTime(2023, 8, 28, 3, 0, 0);
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldNotHaveValidationErrorFor(x => x.EndTime);
        }

        [Fact]
        public void ShouldHaveErrorDateStartSchedule()
        {
            Schedule schedule = new Schedule();
            schedule.StartTime = new DateTime(2022, 4, 28, 3, 0, 0);
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldHaveValidationErrorFor(x => x.StartTime);
        }

        [Fact]
        public void ShouldNotHaveErrorDateStartSchedule()
        {
            Schedule schedule = new Schedule();
            schedule.StartTime = new DateTime(2022, 9, 28, 3, 0, 0);
            TestValidationResult<Schedule>? result = _validator.TestValidate(schedule);
            result.ShouldNotHaveValidationErrorFor(x => x.StartTime);
        }
    }
}
