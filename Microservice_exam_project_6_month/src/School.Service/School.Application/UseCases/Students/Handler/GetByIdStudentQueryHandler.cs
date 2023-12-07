using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Queries;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Students;

namespace School.Application.UseCases.Students.Handler
{
    public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQuery, Student>
    {
        private readonly ISchoolDbContext _dbContext;

        public GetByIdStudentQueryHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.students.FirstOrDefaultAsync(x => x.StudentId == request.Id);
            if (result == null) throw new StudentNotFoundException();
            return result;
        }
    }
}
