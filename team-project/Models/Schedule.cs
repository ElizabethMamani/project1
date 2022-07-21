namespace Models
{
    [Serializable]
    public class Schedule
    {
        public int SubjectId { get; set; }
        public int ScheduleId { get; set; }
        public string Day { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
