using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Teachers.Queries;
using University.Domain.Exceptions.Teachers;
using University.Domain.Models;

namespace University.Application.UseCases.Teachers.Handlers
{
    public class GetByIdTeacherQuerieHandler : IRequestHandler<GetByIdTeacherQuerie, Teacher>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdTeacherQuerieHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher> Handle(GetByIdTeacherQuerie request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.teachers.FirstOrDefaultAsync(x => x.TeacherId == request.Id);
            if (result == null) throw new TeachersNotFoundException();
            return result;
        }
    }
}
