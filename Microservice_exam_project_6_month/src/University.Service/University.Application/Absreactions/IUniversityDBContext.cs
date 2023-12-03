using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Models;

namespace University.Application.Absreactions
{
    public interface IUniversityDBContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<TaskGrade> tasks { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Dedline> dededlines { get; set; }
        public DbSet<CourseGroup> coursegroups { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
