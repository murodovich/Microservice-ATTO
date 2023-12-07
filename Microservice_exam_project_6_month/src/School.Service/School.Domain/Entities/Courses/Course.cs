using School.Domain.Entities.StudentCourses;
using School.Domain.Entities.Subjects;
using School.Domain.Entities.Teachers;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.Courses
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey(nameof(Teachers))]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
