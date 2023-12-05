using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.CourseGroups.Queries;
using University.Domain.Exceptions.CourseGroup;
using University.Domain.Models;

namespace University.Application.UseCases.CourseGroups.Handler
{
    public class GetAllCourseGroupQueryHandler : IRequestHandler<GetAllCourseGroupQuery, List<CourseGroup>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetAllCourseGroupQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseGroup>> Handle(GetAllCourseGroupQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.coursegroups.ToListAsync();
            if (result == null) throw new CourseGroupNotFoundExceptions();
            return result;
        }
    }
}
