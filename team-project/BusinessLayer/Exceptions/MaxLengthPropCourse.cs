// <copyright file="MaxLengthPropCourse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLayer.Exceptions
{
    public class MaxLengthPropCourse : CourseException
    {
        private readonly string property;
        private readonly int maxLength;

        public MaxLengthPropCourse(string property, int maxLength)
        {
            this.property = property;
            this.maxLength = maxLength;
            this.ErrorCode = 4;
            this.ErrorMessage = "In the " + this.property + " field you cannot enter more than " + this.maxLength + " characters";
        }
    }
}
