using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Lessons.Commands;
using University.Domain.Exceptions.Lessons;

namespace University.Application.UseCases.Lessons.Handler
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteLessonCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.lessons.FirstOrDefaultAsync(x => x.LessonId == request.Id);
            if (result == null) throw new LessonsNotFoundException();

            _dbContext.lessons.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
