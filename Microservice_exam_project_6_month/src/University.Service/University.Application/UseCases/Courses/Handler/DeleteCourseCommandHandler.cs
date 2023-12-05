using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Courses.Commands;
using University.Domain.Exceptions.Courseis;

namespace University.Application.UseCases.Courses.Handler
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteCourseCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.courses.FirstOrDefaultAsync(x => x.CourseId == request.Id);
            if (result == null) throw new CourseNotFoundException();

            _dbContext.courses.Remove(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;            
        }
    }
}
