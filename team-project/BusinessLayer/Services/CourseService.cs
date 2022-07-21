namespace BusinessLayer.Services
{
    using BusinessLayer.Exceptions;
    using BusinessLayer.Interfaces;
    using BusinessLayer.Validators;
    using DataAccessLayer.Interfaces;
    using FluentValidation.Results;
    using Models;

    public class CourseService : ICourseService
    {
        private readonly IDataAccessCourses dataAccessCourses;
        private CourseValidator validator;
        public CourseService(IDataAccessCourses dataAccessCourses)
        {
            this.validator = new CourseValidator();
            this.dataAccessCourses = dataAccessCourses;
            this.validator = new CourseValidator();
        }

        public IEnumerable<Course>? GetAllCourses()
        {
            var courses = this.dataAccessCourses.GetAllCourses();
            return courses;
        }

        public Course GetCourse(int id)
        {
            Course result = this.dataAccessCourses.GetCourse(id);
            return result;
        }

        public Course? AddCourse(Course course)
        {

            validator.ValidateCourse(course);
            Course? courseAdded = this.dataAccessCourses.AddCourse(course);
            return courseAdded;
        }

        public Course? UpdateCourse(int id, Course course)
        {
            if (this.dataAccessCourses.GetCourse(id) is null)
            {
                throw new CourseNotFoundException();
            }
            this.validator.ValidateCourse(course);
            Course courseUpdated = this.dataAccessCourses.UpdateCourse(id, course);
            return courseUpdated;
        }

        public bool DeleteCourse(int id)
        {
                int result = this.dataAccessCourses.DeleteCourse(id);
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    throw new CourseNotFoundException();
                }
        }
    }
}