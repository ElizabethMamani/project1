// <copyright file="PastEndDateCourseException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLayer.Exceptions
{
    public class PastEndDateCourseException : CourseException
    {
        public PastEndDateCourseException()
        {
            this.ErrorCode = 6;
            this.ErrorMessage = "The course end date must be later than the start date.";
        }
    }
}
