using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Courses.Commands;
using University.Domain.Exceptions.Courseis;
using University.Domain.Models;

namespace University.Application.UseCases.Courses.Handler
{
    public class GetByIdCourseCommandHandler : IRequestHandler<GetByIdCourseCommand, Course>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdCourseCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Course> Handle(GetByIdCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.courses.FirstOrDefaultAsync(x => x.CourseId == request.Id);
            if (result == null)
            {
                throw new CourseNotFoundException();
            }
            return result;
        }
    }
}
