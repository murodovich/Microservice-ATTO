using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Courses.Queries;
using School.Domain.Entities.Courses;

namespace School.Application.UseCases.Courses.Handler
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, List<Course>>
    {
        private readonly ISchoolDbContext _context;

        public GetAllCourseQueryHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.courses.ToListAsync();
            return result;
        }
    }
}
