using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Subjects.Commands;
using University.Domain.Exceptions.Subject;

namespace University.Application.UseCases.Subjects.Handler
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteSubjectCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.subjects.FirstOrDefaultAsync(x => x.SubjectId == request.Id);
            if (result == null) throw new SubjectNotFoundException();
            _dbContext.subjects.Remove(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
