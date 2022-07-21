
namespace BusinessLayer.Validators
{
    using System.Text;
    using System.Text.RegularExpressions;

    using FluentValidation;
    using FluentValidation.Results;

    using Models;
    using Models.Exceptions;

    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator() 
        {
            Regex regEx = new Regex("^[A-Za-z ]+$");
            this.RuleFor(student => student.Country).NotEmpty().Length(0, 20);
            this.RuleFor(student => student.BirthDate).NotNull().LessThan(DateTime.Today);
            this.RuleFor(student => student.StudentName).Cascade(CascadeMode.Stop).Matches(regEx).NotEmpty().Length(8, 40);
            this.RuleFor(student => student.Email).NotEmpty().EmailAddress().Length(0, 30);
            this.RuleFor(student => student.ImageId).NotEmpty().Length(0, 20);
        }

        public string ValidateStudent(Student student)
        {
            ValidationResult validationResult = this.Validate(student);

            StringBuilder sb = new StringBuilder();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    sb.AppendLine("The Property" + error.PropertyName + ",have the next error : " + error.ErrorMessage);
                }

                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
