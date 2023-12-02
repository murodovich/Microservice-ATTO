namespace University.Domain.Entities.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public Instructor Instructor { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
