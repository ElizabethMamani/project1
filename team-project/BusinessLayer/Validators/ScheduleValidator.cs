using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using Models;

namespace BusinessLayer
{
    public class ScheduleValidator : AbstractValidator<Schedule>
    {
        public ScheduleValidator() {
            Regex regEx = new Regex("^[a-zA-Z]*$");
            this.RuleFor(schedule => schedule.Day).Cascade(CascadeMode.Stop).Matches(regEx).NotEmpty().Length(5, 9);
            this.RuleFor(schedule => schedule.StartTime).NotNull().GreaterThan(DateTime.Today);
            this.RuleFor(schedule => schedule.EndTime).NotNull().GreaterThan(DateTime.Today);
        }

        public void ValidateSchedule(Schedule schedule) {
            ValidationResult validationResult = this.Validate(schedule);
            StringBuilder sb = new StringBuilder();
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    sb.AppendLine("The Property" + error.PropertyName + ",have the next error : " + error.ErrorMessage);
                }
                throw new subjectExeption(sb.ToString());
            }
            if (schedule.EndTime < schedule.StartTime)
            {
                throw new subjectExeption($"The EndTime must be greather than StartTime");
            }
        }
    }
}
