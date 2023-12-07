using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Queries;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Students;

namespace School.Application.UseCases.Students.Handler
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, List<Student>>
    {
        private readonly ISchoolDbContext _dbContext;

        public GetAllStudentQueryHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.students.ToListAsync();
            if (result == null) throw new StudentNotFoundException();
            return result;
        }
    }
}
