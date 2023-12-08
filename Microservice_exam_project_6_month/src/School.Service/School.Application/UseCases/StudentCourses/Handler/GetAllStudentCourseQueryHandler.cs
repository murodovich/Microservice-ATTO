using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.StudentCourses.Queries;
using School.Domain.Entities.StudentCourses;

namespace School.Application.UseCases.StudentCourses.Handler
{
    public class GetAllStudentCourseQueryHandler : IRequestHandler<GetAllStudentCourseQuer, List<StudentCourse>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllStudentCourseQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentCourse>> Handle(GetAllStudentCourseQuer request, CancellationToken cancellationToken)
        {
            var result = await _context.studentsCourse.ToListAsync();
            return result;
        }
    }
}
