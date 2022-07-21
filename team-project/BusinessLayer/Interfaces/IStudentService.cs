namespace BusinessLayer.Interfaces
{
    using Models;

    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudents();

        public Student CreateStudent(Student student);

        public Student GetStudent(int id);

        public Student CreateRelationWithCourse(int studentid, int courseId);
    }
}
