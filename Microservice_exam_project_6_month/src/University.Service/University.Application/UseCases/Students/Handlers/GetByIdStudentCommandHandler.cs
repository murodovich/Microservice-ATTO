using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Students.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Students.Handlers
{
    public class GetByIdStudentCommandHandler : IRequestHandler<GetByIdStudentCommand,Student>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdStudentCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> Handle(GetByIdStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.students.FirstOrDefaultAsync(x => x.StudentId == request.Id);
            return result;
        }
    }
}
