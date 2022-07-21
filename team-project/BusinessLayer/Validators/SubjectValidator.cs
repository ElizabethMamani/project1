
using System.Text;
using System.Text.RegularExpressions;
using DataAccessLayer.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Models;
using Models.Exceptions;

namespace BusinessLayer.Validators
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator(IDataAccessSubjects dataAccessSubjects) {
            Regex regEx = new Regex("^[A-Za-z ]+$");
            if (dataAccessSubjects is not null)
            {
                this.RuleFor(subject => subject.CourseId).Must(x => dataAccessSubjects.ExistsIdCourses(x)).
                WithMessage("This IDCourse dont exist in DB");
                this.RuleFor(subject => subject.SubjectName).Must(x => !dataAccessSubjects.ExistSubjectsName(x)).
                WithMessage(x => $"This Name Subject: {x.SubjectName} exist");
            }

            this.RuleFor(subject => subject.SubjectName).Cascade(CascadeMode.Stop).Matches(regEx).NotEmpty().Length(5, 15);
            this.RuleFor(subject => subject.StartDate).NotNull().GreaterThan(DateTime.Today);
            this.RuleFor(subject => subject.Instructorname).Cascade(CascadeMode.Stop).Matches(regEx).NotEmpty().Length(7, 30);
            this.RuleFor(subject => subject.ImageId).NotEmpty().Length(0, 20);
            this.RuleFor(subject => subject.schedules).NotEmpty();
            this.RuleFor(subject => subject).NotNull();
        }

        public void ValidateSubject(Subject subject) {
          ValidationResult validationResult = this.Validate(subject);
          StringBuilder sb = new StringBuilder();
            if (!validationResult.IsValid)
              {
                foreach (var error in validationResult.Errors)
                   {
                     sb.AppendLine("The Property" + error.PropertyName + ",have the next error : " + error.ErrorMessage);
                   }
                    throw new subjectExeption(sb.ToString());
               }
        }
    }
}
