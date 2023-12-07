using School.Domain.Entities.Courses;
using School.Domain.Entities.Students;
using School.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.StudentCourses
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
