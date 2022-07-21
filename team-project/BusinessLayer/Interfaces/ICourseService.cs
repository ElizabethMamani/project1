namespace BusinessLayer.Interfaces
{
    using Models;

    public interface ICourseService
    {
        public IEnumerable<Course>? GetAllCourses();

        public Course GetCourse(int id);

        public Course? AddCourse(Course course);

        public Course? UpdateCourse(int id, Course course);

        public bool DeleteCourse(int id);

    }
}
