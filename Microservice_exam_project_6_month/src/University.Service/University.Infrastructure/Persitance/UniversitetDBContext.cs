using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Domain.Models;

namespace University.Infrastructure.Persitance
{
    public class UniversitetDBContext : DbContext, IUniversityDBContext
    {
        public UniversitetDBContext(DbContextOptions<UniversitetDBContext> options) : base(options) { }

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

    }
}
