using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Lessons.Commands;
using University.Domain.Exceptions.Lessons;
using static System.Runtime.InteropServices.JavaScript.JSType;
using University.Domain.Models;

namespace University.Application.UseCases.Lessons.Handler
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public UpdateLessonCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.lessons.FirstOrDefaultAsync(x => x.LessonId == request.LessonId);
            if (result == null) throw new LessonsNotFoundException();
            result.LessonId = request.LessonId;
            result.LessonName = request.LessonName;
            result.CourseId = request.CourseId;
            result.Date = request.Date;

            _dbContext.lessons.Update(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }


    }
}
