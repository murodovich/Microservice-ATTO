namespace University.Domain.Entities.Models
{
    public class Attendance
    {
        public int AttendanceId {  get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
