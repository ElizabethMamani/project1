namespace Models
{
    public class Course
    {
        public int CourseId { get; }

        public string CourseName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public string? ImageId { get; set; }
    }
}
