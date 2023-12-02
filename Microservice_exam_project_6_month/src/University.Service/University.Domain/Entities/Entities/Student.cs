namespace University.Domain.Entities.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Shaped { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
