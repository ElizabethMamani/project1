// <copyright file="DataAccessCourses.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DataAccessLayer
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using Dapper;
    using DataAccessLayer.Interfaces;
    using Models;

    [ExcludeFromCodeCoverage]
    public class DataAccessCourses : IDataAccessCourses
    {
        private readonly ConnectionInfoSQL connectionString;
        private IDbConnection? db;

        public DataAccessCourses(ConnectionInfoSQL connection)
        {
            this.connectionString = connection;
        }

        public IEnumerable<Course>? GetAllCourses()
        {
            var procedure = "SP_Course_SelectAll";
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            using (this.db)
            {
                return this.db.Query<Course>(procedure, CommandType.StoredProcedure);
            }
        }

        public Course GetCourse(int id)
        {
            Course course;
            var procedure = "SP_Course_Select";
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@CourseId", id, DbType.Int32, ParameterDirection.Input, int.MaxValue);
            using (this.db)
            {
              course = this.db.QuerySingleOrDefault<Course>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }

            return course;
        }

        public Course? AddCourse(Course course)
        {
            var procedure = "SP_Course_Create";
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            var parameters = new DynamicParameters();
            Course result;
            parameters.Add("@CourseName", course.CourseName, DbType.String, ParameterDirection.Input, 30);
            parameters.Add("@StartDate", course.StartDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@EndDate", course.EndDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Description", course.Description, DbType.String, ParameterDirection.Input, 50);
            parameters.Add("@ImageId", course.ImageId, DbType.String, ParameterDirection.Input, 20);
            using (this.db)
            {
                result = this.db.QuerySingleOrDefault<Course>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public Course? UpdateCourse(int id, Course course)
        {
            var procedure = "SP_Course_Edit";
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            var parameters = new DynamicParameters();
            int result = 0;
            parameters.Add("@CourseId", id, DbType.Int32, ParameterDirection.Input, int.MaxValue);
            parameters.Add("@CourseName", course.CourseName, DbType.String, ParameterDirection.Input, 30);
            parameters.Add("@StartDate", course.StartDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@EndDate", course.EndDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Description", course.Description, DbType.String, ParameterDirection.Input, 50);
            parameters.Add("@ImageId", course.ImageId, DbType.String, ParameterDirection.Input, 20);
            using (this.db)
            {
                result = this.db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }

            if (result == 1)
            {
                return course;
            }
            else
            {
                return null;
            }
        }

        public int DeleteCourse(int id)
        {
            var procedure = "SP_Course_Delete";
            this.db = new SqlConnection(this.connectionString.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@CourseId", id, DbType.Int32, ParameterDirection.Input, int.MaxValue);
            int result;
            using (this.db)
            {
                result = this.db.Execute(procedure, parameter, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
