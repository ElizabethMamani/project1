// <copyright file="RepeatedCourseException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLayer.Exceptions
{
    public class RepeatedCourseException : CourseException
    {
        public RepeatedCourseException()
        {
            this.ErrorCode = 3;
            this.ErrorMessage = "The course has already been registered.";
        }
    }
}
