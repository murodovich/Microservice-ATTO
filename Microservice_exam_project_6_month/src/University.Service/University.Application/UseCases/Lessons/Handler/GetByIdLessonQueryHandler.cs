using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Lessons.Queries;
using University.Domain.Exceptions.Lessons;
using University.Domain.Models;

namespace University.Application.UseCases.Lessons.Handler
{
    public class GetByIdLessonQueryHandler : IRequestHandler<GetByIdLessonQuery, Lesson>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdLessonQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Lesson> Handle(GetByIdLessonQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.lessons.FirstOrDefaultAsync(x => x.LessonId == request.Id);
            if (result == null) throw new LessonsNotFoundException();
            return result;
        }
    }
}
