using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Commands;
using School.Domain.Exceptions.Students;

namespace School.Application.UseCases.Students.Handler
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly ISchoolDbContext _dbContext;

        public DeleteStudentCommandHandler(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.students.FirstOrDefaultAsync(x => x.StudentId == request.Id);
            if (result == null) throw new StudentNotFoundException();
            
            _dbContext.students.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;

        }
    }
}
