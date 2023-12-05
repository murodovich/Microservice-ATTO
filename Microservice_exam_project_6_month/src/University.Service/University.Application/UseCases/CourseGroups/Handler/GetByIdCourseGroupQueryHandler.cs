using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.CourseGroups.Queries;
using University.Domain.Exceptions.CourseGroup;
using University.Domain.Models;

namespace University.Application.UseCases.CourseGroups.Handler
{
    public class GetByIdCourseGroupQueryHandler : IRequestHandler<GetByIdCourseGroupQuery, CourseGroup>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdCourseGroupQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CourseGroup> Handle(GetByIdCourseGroupQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.coursegroups.FirstOrDefaultAsync(x => x.CourseGroupId == request.Id);
            if (result == null) throw new CourseGroupNotFoundExceptions();
            return result;
        }
    }
}
