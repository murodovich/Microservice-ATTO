using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Entities;

namespace University.Application.Absreactions
{
    public interface IUniversityDBContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CourseEnrollment> enrollments { get; set; }
        public DbSet<Department> departments { get; set; }  
        public DbSet<Instructor> instructors { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
