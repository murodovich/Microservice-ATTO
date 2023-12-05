using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Lessons.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Lessons.Handler
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreateLessonCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var result = new Lesson()
            {
                CourseId = request.CourseId,
                LessonName = request.LessonName,
                Date = request.Date,
            };

            await _dbContext.lessons.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }

    }
}
