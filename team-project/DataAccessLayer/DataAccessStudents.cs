
namespace DataAccessLayer
{
    using System.Data;

    using System.Data.SqlClient;

    using Dapper;

    using DataAccessLayer.Interfaces;

    using Models;

    public class DataAccessStudents : IDataAccessStudents
    {
        private readonly ConnectionInfoSQL connectionString;

        private IDbConnection db;

        public DataAccessStudents(ConnectionInfoSQL connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Student>? GetAllStudents()
        {
            var procedure = "getAllStudents";
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            using (this.db)
            {
                return this.db.Query<Student>(procedure, commandType: CommandType.StoredProcedure);
            }
        }

        public Student GetStudent(int id)
        {
            Student result;
            var procedure = "getStudent";
            var parameters = new DynamicParameters();
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            parameters.Add("@StudentId", id, DbType.Int32, ParameterDirection.Input, int.MaxValue);
            using (this.db)
            {
                result = this.db.QuerySingleOrDefault<Student>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public Student CreateStudent(Student student)
        {
            var procedure = "createStudent";
            var parameters = new DynamicParameters();
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            parameters.Add("@StudentName", student.StudentName, DbType.String, ParameterDirection.Input, 40);
            if (student.CourseId != 0)
            {
                parameters.Add("@CourseId", student.CourseId, DbType.String, ParameterDirection.Input, 40);
            }

            parameters.Add("@Email", student.Email, DbType.String, ParameterDirection.Input, 30); 
            parameters.Add("@BirthDate", student.BirthDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Country", student.Country, DbType.String, ParameterDirection.Input, 20);
            parameters.Add("ImageId", student.ImageId, DbType.String, ParameterDirection.Input, int.MaxValue);
            using (this.db)
            {
                return this.db.QuerySingleOrDefault<Student>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int CreateRelationWithCourse(int studentId, int courseId)
        {
            int result = 0;
            var procedure = "relationStudentCourse";
            var parameters = new DynamicParameters();
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            parameters.Add("@StudentId", studentId, DbType.Int32, ParameterDirection.Input, int.MaxValue);
            parameters.Add("@CourseId", courseId, DbType.Int32, ParameterDirection.Input, int.MaxValue);
            using (this.db)
            {
                return this.db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ExistsIdCoursesInCourses(int id_course)
        {
            List<Int16> ListCourse = new List<Int16>();
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            using (this.db)
            {
                ListCourse = this.db.Query<Int16>("SELECT CourseId FROM Course").ToList();
            }

            return ListCourse.Any(item => item == id_course);
        }
    }
}
