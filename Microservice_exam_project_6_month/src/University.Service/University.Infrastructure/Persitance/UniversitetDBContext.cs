using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Domain.Models;
using University.Infrastructure.Configuration.Attendanceis;
using University.Infrastructure.Configuration.CourseGroups;
using University.Infrastructure.Configuration.Courses;
using University.Infrastructure.Configuration.Dedlines;
using University.Infrastructure.Configuration.Groups;
using University.Infrastructure.Configuration.Lessons;
using University.Infrastructure.Configuration.Student;
using University.Infrastructure.Configuration.Subjects;
using University.Infrastructure.Configuration.TaskGrads;
using University.Infrastructure.Configuration.Teachers;

namespace University.Infrastructure.Persitance
{
    public class UniversitetDBContext : DbContext, IUniversityDBContext
    {
        public UniversitetDBContext(DbContextOptions<UniversitetDBContext> options) : base(options) 
        {
            Database.Migrate();
        }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new CourseGroupConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new DedlineConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskGradeConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());

        }

    }
}
