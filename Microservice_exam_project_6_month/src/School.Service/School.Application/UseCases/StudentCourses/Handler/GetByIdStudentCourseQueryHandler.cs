using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.StudentCourses.Queries;
using School.Domain.Entities.StudentCourses;
using School.Domain.Exceptions.StudentCourses;

namespace School.Application.UseCases.StudentCourses.Handler
{
    public class GetByIdStudentCourseQueryHandler : IRequestHandler<GetByIdStudentCourseQuery, StudentCourse>
    {
        private readonly ISchoolDbContext _context;

        public GetByIdStudentCourseQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<StudentCourse> Handle(GetByIdStudentCourseQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.studentsCourse.FirstOrDefaultAsync(x => x.StudentCourseId == request.Id);
            if (result == null) throw new StudentCourseNotFoundException();
            return result;
        }
    }
}
