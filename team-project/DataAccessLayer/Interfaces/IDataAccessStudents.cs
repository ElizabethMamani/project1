
namespace DataAccessLayer.Interfaces
{
    using Models;

    public interface IDataAccessStudents
    {
        public IEnumerable<Student>? GetAllStudents();

        public Student GetStudent(int id);

        public Student CreateStudent(Student student);

        public int CreateRelationWithCourse(int studentId, int courseId);

        public bool ExistsIdCoursesInCourses(int id_course);

    }
}