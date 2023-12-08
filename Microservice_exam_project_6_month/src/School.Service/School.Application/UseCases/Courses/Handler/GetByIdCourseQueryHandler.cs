using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Courses.Queries;
using School.Domain.Entities.Courses;
using School.Domain.Exceptions.Courses;

namespace School.Application.UseCases.Courses.Handler
{
    public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQuery, Course>
    {
        private readonly ISchoolDbContext _dbContext;

        public GetByIdCourseQueryHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Course> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.courses.FirstOrDefaultAsync(x => x.CourseId == request.Id);
            if (result == null) throw new CourseNotFoundException();
            return result;
        }
    }
}
