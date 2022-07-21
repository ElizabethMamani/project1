namespace BusinessLayer.Services
{

    using BusinessLayer.Interfaces;
    using BusinessLayer.Validators;
    using DataAccessLayer.Interfaces;
    using Models;

    public class StudentService : IStudentService
    {
        private readonly IDataAccessStudents dataAccess;

        public StudentService(IDataAccessStudents dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            IEnumerable<Student>? list = this.dataAccess.GetAllStudents();
            return list;
        }

        public Student CreateStudent(Student student)
        {
            StudentValidator studentValidator = new StudentValidator();
            var errors = studentValidator.ValidateStudent(student);
            if (errors != string.Empty)
            {
                throw new Exception(errors);
            }

            return this.dataAccess.CreateStudent(student);
        }

        public Student GetStudent(int id)
        {
            Student student = this.dataAccess.GetStudent(id);
            return student;
        }

        public Student CreateRelationWithCourse(int studentid, int courseId)
        {
            if (!this.dataAccess.ExistsIdCoursesInCourses(courseId))
            {
                throw new ArgumentException("This IdCourse not exist in courses");
            }

            Student result = this.GetStudent(studentid);
            if (result is not null)
            {
                if (result.CourseId == 0)
                {
                    this.dataAccess.CreateRelationWithCourse(studentid, courseId);
                    result = this.GetStudent(studentid);
                }
                else
                {
                    throw new ArgumentException("This student already are assigned with a course");
                }
            }
            else
            {
                throw new ArgumentException("The student with that id does not exist");
            }
            return result;
        }
    }
}
