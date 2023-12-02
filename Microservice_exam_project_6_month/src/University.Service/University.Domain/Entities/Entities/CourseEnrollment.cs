namespace University.Domain.Entities.Entities
{
    public class CourseEnrollment
    {
        public int CourseEnrollmentId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
