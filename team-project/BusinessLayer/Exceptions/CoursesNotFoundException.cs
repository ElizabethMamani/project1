// <copyright file="CoursesNotFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLayer.Exceptions
{
    public class CoursesNotFoundException : CourseException
    {
        public CoursesNotFoundException()
        {
            this.ErrorCode = 1;
            this.ErrorMessage = "There are no registered courses.";
        }
    }
}
