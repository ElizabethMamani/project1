// <copyright file="PastStartDateCourseException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLayer.Exceptions
{
    public class PastStartDateCourseException : CourseException
    {
        public PastStartDateCourseException()
        {
            this.ErrorCode = 5;
            this.ErrorMessage = "The course start date must be equal to or later than the current date.";
        }
    }
}
