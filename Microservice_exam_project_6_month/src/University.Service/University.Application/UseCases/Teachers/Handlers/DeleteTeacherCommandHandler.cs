using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Teachers.Commands;
using University.Domain.Exceptions.Teachers;

namespace University.Application.UseCases.Teachers.Handlers
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteTeacherCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.teachers.FirstOrDefaultAsync(x => x.TeacherId == request.Id);
            if (result == null) throw new TeachersNotFoundException();
            _dbContext.teachers.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
