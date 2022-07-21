namespace TestBussinessLayer
{
    using BusinessLayer.Validators;
    using FluentValidation.TestHelper;
    using Models;
    using Xunit;

    public class StudentValidatorTests
    {
        private readonly StudentValidator _validator;

        public StudentValidatorTests()
        {
            _validator = new StudentValidator();
        }

        [Fact]
        public void ShouldHaveErrorBirthDateStudentTest()
        {
            Student student = new ()
            {
                StudentName = "Roberto Vargas",
                Country = "Bolivia",
                BirthDate = new System.DateTime(2022, 07, 25),
                Email = "jual@gmail.com",
                ImageId = "perfilPhoto",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void DontShouldHaveErrorBirthDateStudentTest()
        {
            Student student = new ()
            {
                StudentName = "Roberto Vargas",
                Country = "Bolivia",
                BirthDate = new System.DateTime(2010, 07, 25),
                Email = "jual@gmail.com",
                ImageId = "perfilPhoto",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldNotHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void ShouldHaveErrorBirthDateStudentNullTest()
        {
            Student student = new ()
            {
                StudentName = "Roberto Vargas",
                Country = "Bolivia",
                BirthDate = null,
                Email = "jual@gmail.com",
                ImageId = "perfilPhoto",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void ShouldHaveErrorEmailStudentTest()
        {
            Student student = new ()
            {
                StudentName = "Roberto Vargas",
                Country = "Bolivia",
                BirthDate = new System.DateTime(2022, 07, 25),
                Email = "aaadddd121212dsd",
                ImageId = "perfilPhoto",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void ShouldHaveErrorEmailStudent2Test()
        {
            Student student = new ()
            {
                Email = "robertogmail.com",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void ShouldHaveErrorEmailStudentEmptyTest()
        {
            Student student = new ()
            {
                Email = " ",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void ShouldNotHaveErrorEmailStudentTest()
        {
            Student student = new ()
            {
                Email = "roberto@gmail.com",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void ShouldHaveErrorImageStudentLargeTest()
        {
            Student student = new ()
            {
                ImageId = "t92385y32f9uh3298r938247923865923",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.ImageId);
        }

        [Fact]
        public void ShouldNotHaveErrorImageStudentTest()
        {
            Student student = new ()
            {
                ImageId = "./src/image",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldNotHaveValidationErrorFor(x => x.ImageId);
        }

        [Fact]
        public void ShouldHaveErrorImageStudentEmptyTest()
        {
            Student student = new ()
            {
                ImageId = " ",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.ImageId);
        }

        [Fact]
        public void ShouldHaveErrorCountryStudentLargeTestTest()
        {
            Student student = new ()
            {
                StudentName = "Roberto Vargas",
                Country = "Boliviaqwriweirulhweilurhliuhwrhluweirh",
                BirthDate = new System.DateTime(2022, 07, 25),
                Email = "jual@gmail.com",
                ImageId = "perfilPhoto",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.Country);
        }

        [Fact]
        public void ShouldHaveErrorCountryStudentNoEmptyTest()
        {
            Student student = new ()
            {
                StudentName = "Roberto Vargas",
                Country = " ",
                BirthDate = new System.DateTime(2022, 07, 25),
                Email = "jual@gmail.com",
                ImageId = "perfilPhoto",
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.Country);
        }

        [Fact]
        public void ShouldNotHaveErrorCountryStudentTest()
        {
            Student student = new ()
            {
                Country = "Bolivia"
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldNotHaveValidationErrorFor(x => x.Country);
        }

        [Fact]
        public void ShouldHaveErrorStudentNameTest()
        {
            Student student = new ()
            {
                StudentName = "lolololololololololodadadadadadadlolololo"
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.StudentName);
        }

        [Fact]
        public void ShouldHaveErrorStudentNameTwoTest()
        {
            Student student = new ()
            {
                StudentName = "lo"
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(x => x.StudentName);
        }

        [Fact]
        public void ShouldNotHaveErrorStudentNameTwoTest()
        {
            Student student = new ()
            {
                StudentName = "Laura Leon"
            };
            TestValidationResult<Student>? result = _validator.TestValidate(student);
            result.ShouldNotHaveValidationErrorFor(x => x.StudentName);
        }
    }
}
