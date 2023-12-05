using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Courses.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Courses.Handler
{
    public class CreatCourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreatCourseCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course()
            {
                CourseName = request.CourseName,
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId,
            };
            await _dbContext.courses.AddAsync(course);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
