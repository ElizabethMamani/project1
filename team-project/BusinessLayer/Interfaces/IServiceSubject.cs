using Models;

namespace BusinessLayer
{
    public interface IServiceSubject 
    {
        public IEnumerable<Subject> GetAllSubjects();

        public Subject? GetSubject(int id_subject);

        public List<Subject> GetSubjectsByIdCourse(int id_Course);

        public Subject? SaveSubject(Subject subject);

        
    }
}

