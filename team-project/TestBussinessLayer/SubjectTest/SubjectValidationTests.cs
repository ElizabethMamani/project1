namespace TestBussinessLayer.SubjectTest
{
    using BusinessLayer.Validators;
    using DataAccessLayer.Interfaces;
    using FluentValidation.TestHelper;
    using Models;
    using Xunit;

    public class SubjectValidationTests
    {
        private readonly SubjectValidator _validator;
        private readonly IDataAccessSubjects _dataAccessSubjects;

        public SubjectValidationTests()
        {
            _validator = new SubjectValidator(_dataAccessSubjects);
        }

        [Fact]
        public void ShouldHaveErrorNameSubjectTest()
        {
            Subject subject = new Subject();
            subject.SubjectName = "B";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.SubjectName);
        }

        [Fact]
        public void ShouldHaveErrorNameSubjectEmptyTest()
        {
            Subject subject = new Subject();
            subject.SubjectName = " ";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.SubjectName);
        }

        [Fact]
        public void DontShouldHaveErrorNameSubjectTest()
        {
            Subject subject = new Subject();
            subject.SubjectName = "Backend";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldNotHaveValidationErrorFor(x => x.SubjectName);
        }

        [Fact]
        public void DontShouldHaveErrorInstructorNameSubjectTest()
        {
            Subject subject = new Subject();
            subject.Instructorname = "Juan Gonzales";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldNotHaveValidationErrorFor(x => x.Instructorname);
        }

        [Fact]
        public void ShouldHaveErrorInstructorNameSubjectEmptyTest()
        {
            Subject subject = new Subject();
            subject.Instructorname = " ";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.Instructorname);
        }

        [Fact]
        public void ShouldHaveErrorInstructorNameShortSubjectTest()
        {
            Subject subject = new Subject();
            subject.Instructorname = "Juan";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.Instructorname);
        }

        [Fact]
        public void ShouldHaveErrorDateSubjectTest()
        {
            Subject subject = new Subject();
            subject.StartDate = new DateTime(2022, 5, 28, 3, 0, 0);
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void ShouldNotHaveErrorDateSubjectTest()
        {
            Subject subject = new Subject();
            subject.StartDate = new DateTime(2023, 5, 28, 3, 0, 0);
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldNotHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void ShouldDontHaveErrorImageSubjectTest()
        {
            Subject subject = new Subject();
            subject.ImageId = "./src/Image/Icon.jpg";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldNotHaveValidationErrorFor(x => x.ImageId);
        }

        [Fact]
        public void ShouldHaveErrorImageNullSubjectTest()
        {
            Subject subject = new Subject();
            subject.ImageId = " ";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.ImageId);
        }

        [Fact]
        public void ShouldHaveErrorImageSubjectTest()
        {
            Subject subject = new Subject();
            subject.ImageId = "./src/Image/Icon.jpgdadadadadadadadadadddddddddddddddddd";
            TestValidationResult<Subject>? result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.ImageId);
        }
    }
}
