namespace TestBussinessLayer
{
    using BusinessLayer.Validators;
    using FluentValidation.TestHelper;
    using Models;
    using Xunit;

    public class CourseValidatorTest
    {
        private readonly CourseValidator _validator;

        public CourseValidatorTest()
        {
            _validator = new CourseValidator();
        }

        [Fact]
        public void Validator_error_for_CourseNameNull()
        {
            Course course = new ();
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.CourseName);
        }

        [Fact]
        public void Validator_error_for_CourseNameEmpty()
        {
            Course course = new ();
            course.CourseName = string.Empty;
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.CourseName);
        }

        [Fact]
        public void Validator_NotError_for_CourseName()
        {
            Course course = new ();
            course.CourseName = "Backend";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldNotHaveValidationErrorFor(x => x.CourseName);
        }

        [Fact]
        public void Validator_error_for_CourseNameMaxNameLength()
        {
            Course course = new ();
            course.CourseName = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.CourseName);
        }

        [Fact]
        public void Validator_error_for_CourseNameMaxNameShort()
        {
            Course course = new ();
            course.CourseName = "ddd";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.CourseName);
        }

        [Fact]
        public void Validator_Noterror_for_CourseNameMaxNameLength()
        {
            Course course = new ();
            course.CourseName = "FrontEnd";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldNotHaveValidationErrorFor(x => x.CourseName);
        }

        [Fact]
        public void Validator_error_for_CourseDescriptionNull()
        {
            Course course = new ();
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Validator_error_for_CourseDescriptionEmpty()
        {
            Course course = new ();
            course.Description = string.Empty;
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Validator_error_for_CourseDescriptionLength()
        {
            Course course = new ();
            course.Description = "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Validator_Not_Error_for_CourseDescriptionLength()
        {
            Course course = new ();
            course.Description = "una gran descripcion";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Validator_error_for_CourseImageIdLength()
        {
            Course course = new ();
            course.ImageId = "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.ImageId);
        }

        [Fact]
        public void Validator_Not_Error_for_CourseImageIdLength()
        {
            Course course = new ();
            course.ImageId = "./images";
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldNotHaveValidationErrorFor(x => x.ImageId);
        }

        [Fact]
        public void Validator_error_for_StartDatePast()
        {
            Course course = new ();
            course.StartDate = new DateTime(2000, 1, 1);
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void Validator_Not_Error_for_StartDatePast()
        {
            Course course = new ();
            course.StartDate = new DateTime(2023, 1, 1);
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldNotHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void Validator_error_for_EndDateEarly()
        {
            Course course = new ();
            course.StartDate = new DateTime(2030, 7, 1);
            course.EndDate = new DateTime(2022, 1, 1);
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(x => x.EndDate);
        }

        [Fact]
        public void Validator_Not_Error_for_EndDateEarly()
        {
            Course course = new ();
            course.StartDate = new DateTime(2021, 7, 1);
            course.EndDate = new DateTime(2022, 1, 1);
            TestValidationResult<Course> result = _validator.TestValidate(course);
            result.ShouldNotHaveValidationErrorFor(x => x.EndDate);
        }
    }
}
