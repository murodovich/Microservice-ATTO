using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Entities.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public string LessonName { get; set; } 
        public DateTime Date { get; set; }
        public Course Course { get; set;}
        


    }
}
