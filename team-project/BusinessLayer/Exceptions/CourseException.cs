// <copyright file="CourseException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLayer.Exceptions
{
    public class CourseException : Exception
    {
        private string errorMessage = string.Empty;
        private int errorCode;

        public CourseException(int errorCode, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.ErrorCode = errorCode;
        }

        public CourseException()
        {
        }

        public CourseException(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }

            set
            {
                this.errorMessage = value;
            }
        }

        public int ErrorCode
        {
            get
            {
                return this.errorCode;
            }

            set
            {
                this.errorCode = value;
            }
        }
    }
}
