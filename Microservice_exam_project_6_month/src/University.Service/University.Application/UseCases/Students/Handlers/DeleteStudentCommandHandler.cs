using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Students.Commands;

namespace University.Application.UseCases.Students.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand,bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteStudentCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _dbContext.students.FirstOrDefaultAsync(x => x.StudentId == request.Id);
            if (student == null)
            {
                return false;
            }
            _dbContext.students.Remove(student);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
