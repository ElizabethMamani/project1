namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class Subject
    {
        public int CourseId { get; set; }

        public int SubjectId { get; set; }

        public string? SubjectName { get; set; }

        public DateTime StartDate { get; set; }

        public string? Instructorname { get; set; }

        public string? ImageId { get; set; }

        public List<Schedule>? schedules { get; set; }

    }
}
