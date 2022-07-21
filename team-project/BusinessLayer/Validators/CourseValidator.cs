namespace BusinessLayer.Validators
{
    using BusinessLayer.Exceptions;
    using FluentValidation;
    using FluentValidation.Results;
    using Models;
    using System.Text;

    public class CourseValidator : AbstractValidator<Course>
    {
        private static readonly int MaxNameLength = 30;
        private static readonly int MaxDescriptionLength = 50;
        private static readonly int MaxImageIdLength = 20;

        public CourseValidator()
        {
            this.RuleFor(course => course.CourseName)
                .NotNull()
                .WithMessage("The course name is required. ")
                .NotEmpty()
                .WithMessage("The course name is required. ")
                .MaximumLength(MaxNameLength)
                .WithMessage("In the name field you cannot enter more than " + MaxNameLength + " characters. ")
                .MinimumLength(5);

            this.RuleFor(course => course.Description)
                .NotNull()
                .WithMessage("The course description is required. ")
                .NotEmpty()
                .WithMessage("The course description is required. ")
                .MaximumLength(MaxDescriptionLength)
                .WithMessage("In the description field you cannot enter more than " + MaxDescriptionLength + " characters. ");

            this.When(course => !string.IsNullOrEmpty(course.ImageId), () =>
            {
                this.RuleFor(course => course.ImageId)
                .MaximumLength(MaxImageIdLength)
                .WithMessage("In the description field you cannot enter more than " + MaxDescriptionLength + " characters. ");
            });

            this.RuleFor(course => course.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("The course start date must be equal to or later than the current date. ");

            this.RuleFor(course => course.EndDate)
                .GreaterThan(course => course.StartDate)
                .WithMessage("The course end date must be later than the start date. ");
        }
        public void ValidateCourse(Course course) {
            ValidationResult results = this.Validate(course);
            StringBuilder sb = new StringBuilder();
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    sb.AppendLine("The Property" + error.PropertyName + ",have the next error : " + error.ErrorMessage);
                }
                throw new CourseException(sb.ToString());
            }
        }
    }
}
