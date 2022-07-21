using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public  interface IDataAccessSubjects
    {
        public List<Subject> GetAll();
        public bool ExistsIdCourses(int id_course);
        public bool ExistSubjectsName(string subject_name);
        public Subject GetSubject(int id_subject);

        public int GetSubjectIDByName(string nameSubject);
        public List<Subject> GetListSubjectByIDCourse(int idCourse);

        public Subject Save(Subject subject);
    }
}
