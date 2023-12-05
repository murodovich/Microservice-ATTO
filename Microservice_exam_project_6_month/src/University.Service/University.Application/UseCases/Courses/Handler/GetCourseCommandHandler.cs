using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Courses.Queries;
using University.Domain.Exceptions.Courseis;
using University.Domain.Models;

namespace University.Application.UseCases.Courses.Handler
{
    public class GetCourseCommandHandler : IRequestHandler<GetCourseCommand, List<Course>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetCourseCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Course>> Handle(GetCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.courses.ToListAsync(cancellationToken);
            if (result == null) throw new CourseNotFoundException();
            return result;
            
        }
    }
}
