using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.TaskGrads.Queries;
using University.Domain.Exceptions.TaskGrade;
using University.Domain.Models;

namespace University.Application.UseCases.TaskGrads.Handler
{
    public class GetAllTaskGradeQueryHandler : IRequestHandler<GetAllTaskGradeQuery, List<TaskGrade>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetAllTaskGradeQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskGrade>> Handle(GetAllTaskGradeQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.tasks.ToListAsync();
            if (result == null) throw new TaskGradeNotFoundException();
            return result;
        }
    }
}
