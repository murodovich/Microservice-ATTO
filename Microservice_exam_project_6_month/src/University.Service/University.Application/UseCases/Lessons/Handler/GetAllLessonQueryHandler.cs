using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Lessons.Queries;
using University.Domain.Exceptions.Lessons;
using University.Domain.Models;

namespace University.Application.UseCases.Lessons.Handler
{
    public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonQuery, List<Lesson>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetAllLessonQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Lesson>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.lessons.ToListAsync();
            if (result == null) throw new LessonsNotFoundException();
            return result;
        }
    }
}
