namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;
    using DataAccessLayer.Interfaces;
    using Models;

    public class DataAccessSubjects : IDataAccessSubjects
    {
        public List<Subject> ListSubject = new List<Subject>();
        public List<Schedule> ListSchedule = new List<Schedule>();
        public List<Int16> ListCourse = new List<Int16>();
        private readonly ConnectionInfoSQL connectionString;

        public DataAccessSubjects(ConnectionInfoSQL connection)
        {
            this.connectionString = connection;
        }

        public DataAccessSubjects() { }

        public List<Subject> GetAll()
        {
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                this.ListSubject = db.Query<Subject>("SELECT * FROM Subject").ToList();
                this.ListCourse = db.Query<Int16>("SELECT CourseId FROM Course").ToList();
                this.ListSchedule = db.Query<Schedule>("SELECT * FROM Schedule").ToList();
            }

            this.SetListSubjets();
            return this.ListSubject;
        }
        public bool ExistsIdCourses(int id_course)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                this.ListCourse = db.Query<Int16>("SELECT CourseId FROM Course").ToList();
            }
            return this.ListCourse.Any(item => item == id_course);
        }

        private void SetListSubjets()
        {
            List<Schedule> newList = new List<Schedule>();
            foreach (var item in ListSubject)
            {
                foreach (var item2 in this.ListSchedule)
                {
                    if (item.SubjectId == item2.SubjectId)
                    {
                        newList.Add(item2);
                    }
                }
                item.schedules = newList;
                newList = new List<Schedule>();
            }
        }

        public Subject? GetSubject(int id_subject)
        {
            Subject subject;
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                var sP = "Select_By_Id_Subject";
                var parameters = new DynamicParameters();
                parameters.Add("@SubjectId", id_subject, DbType.Int32, ParameterDirection.Input, int.MaxValue);
                subject = db.QuerySingleOrDefault<Subject>(sP, parameters, commandType: CommandType.StoredProcedure);
                if (subject is not null)
                {
                    subject.schedules = GetSchedule(id_subject);
                }

                return subject;
            }
        }

        public bool ExistSubjectsName(string subject_name)
        {
            List<String> ListNameSubjects = new List<string>();
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                ListNameSubjects = db.Query<String>("SELECT SubjectName FROM Subject").ToList();
            }
            return ListNameSubjects.Any(item => item == subject_name);
        }

        private List<Schedule> GetSchedule(int? id_subject)
        {
            List<Schedule> schedules = new List<Schedule>();
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                var sP = "Select_By_Id_Schedule";
                var parameters = new DynamicParameters();
                parameters.Add("@SubjectId", id_subject, DbType.Int32, ParameterDirection.Input, int.MaxValue);
                schedules = db.Query<Schedule>(sP, parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return schedules;
        }

        public int GetSubjectIDByName(string nameSubject)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                var sP = "Select_By_Name_Subject";
                var parameters = new DynamicParameters();
                parameters.Add("@SubjectName", nameSubject, DbType.String, ParameterDirection.Input);
                int subjectId = db.QuerySingle<int>(sP, parameters, commandType: CommandType.StoredProcedure);
                return subjectId;
            }
        }

        public List<Subject> GetListSubjectByIDCourse(int idCourse)
        {
            GetAll();
            List<Subject> subjectsByCourse = new List<Subject>();
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                var sP = "Select_By_Id_Course_Subjects";
                var parameters = new DynamicParameters();
                parameters.Add("@CourseId", idCourse, DbType.Int32, ParameterDirection.Input, int.MaxValue);
                this.ListSubject = db.Query<Subject>(sP, parameters, commandType: CommandType.StoredProcedure).ToList();
                this.SetListSubjets();
                return this.ListSubject;
            }
        }

        public Subject? Save(Subject subject)
        {
            int result;
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                var sP = "Add_Subject";
                var name = subject.SubjectName;
                var parameters = new DynamicParameters();
                parameters.Add("@CourseId", subject.CourseId, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@SubjectName", name, DbType.String, ParameterDirection.Input);
                parameters.Add("@StartDate", subject.StartDate, DbType.Date, ParameterDirection.Input);
                parameters.Add("@Instructorname", subject.Instructorname, DbType.String, ParameterDirection.Input);
                parameters.Add("@ImageId", subject.ImageId, DbType.String, ParameterDirection.Input);

                result = db.Execute(sP, parameters, commandType: CommandType.StoredProcedure);

                if (result == 1)
                {
                    for (int i = 0; i < subject.schedules.Count; i++)
                    {
                        this.InsertSchedule(subject.schedules[i], subject.SubjectName);
                    }
                    return subject;
                }
                else { return new Subject(); }
            }
        }

        private void InsertSchedule(Schedule schedule, string nameSubject)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString.ConnectionString))
            {
                var sP = "Add_Schedule";
                var idSubject = this.GetSubjectIDByName(nameSubject);
                var parameters = new DynamicParameters();
                parameters.Add("@SubjectId", idSubject, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@Day", schedule.Day, DbType.String, ParameterDirection.Input);
                parameters.Add("@StartTime", schedule.StartTime, DbType.Date, ParameterDirection.Input);
                parameters.Add("@EndTime", schedule.EndTime, DbType.Date, ParameterDirection.Input);

                db.Execute(sP, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
