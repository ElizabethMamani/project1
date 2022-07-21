

namespace Models
{
    [Serializable]
    public class Student
    {
        public string? StudentName { get; set; }

        public int StudentId { get; set; } = 0;

        public int CourseId { get; set; } = 0;

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; } = null;

        public string Country { get; set; }

        public string ImageId { get; set; }
    }
}
