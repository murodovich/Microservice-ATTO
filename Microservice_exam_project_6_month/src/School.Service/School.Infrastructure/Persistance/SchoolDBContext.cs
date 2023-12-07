﻿using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Domain.Entities.Courses;
using School.Domain.Entities.StudentCourses;
using School.Domain.Entities.Students;
using School.Domain.Entities.Subjects;
using School.Domain.Entities.Teachers;

namespace School.Infrastructure.Persistance
{
    public class SchoolDBContext : DbContext, ISchoolDbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
            Database.Migrate();

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentCourse> studentsCourse { get; set; }




    }
}
