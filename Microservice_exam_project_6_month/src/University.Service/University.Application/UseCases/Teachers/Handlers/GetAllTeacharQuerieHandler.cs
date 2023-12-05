using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Teachers.Queries;
using University.Domain.Exceptions.Teachers;
using University.Domain.Models;

namespace University.Application.UseCases.Teachers.Handlers
{
    public class GetAllTeacharQuerieHandler : IRequestHandler<GetAllTeacherQuerie, List<Teacher>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetAllTeacharQuerieHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Teacher>> Handle(GetAllTeacherQuerie request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.teachers.ToListAsync();
            if (result == null) throw new TeachersNotFoundException();
            return result;
        }
    }
}
