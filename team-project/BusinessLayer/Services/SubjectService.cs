
using Models;
using Models.Exceptions;
using DataAccessLayer.Interfaces;
using BusinessLayer.Validators;

namespace BusinessLayer
{
    public class SubjectService : IServiceSubject
    {
        private ScheduleValidator scheduleService;

        private IDataAccessSubjects dataAccessSubjects;
        public SubjectService(IDataAccessSubjects dataAccessSubjects) {
            this.dataAccessSubjects = dataAccessSubjects;
            this.scheduleService = new ScheduleValidator();
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.dataAccessSubjects.GetAll();
        }

        public Subject? GetSubject(int id_subject) {
            Subject result = this.dataAccessSubjects.GetSubject(id_subject);
            return result;
        }

        public List<Subject> GetSubjectsByIdCourse(int id_Course) {
            List <Subject> result = this.dataAccessSubjects.GetListSubjectByIDCourse(id_Course);
            return result;
        }

        public Subject? SaveSubject(Subject subject)
        {
                SubjectValidator? subjectValidation = new SubjectValidator(this.dataAccessSubjects);
                subjectValidation.ValidateSubject(subject);

                for (int i = 0; i < subject.schedules.Count; i++)
                {
                    this.scheduleService.ValidateSchedule(subject.schedules[i]);
                }

                Subject? result = this.dataAccessSubjects.Save(subject);
                return result;
        }
    }
}
