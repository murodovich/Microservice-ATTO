using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Subjects.Commands;
using University.Domain.Exceptions.Subject;

namespace University.Application.UseCases.Subjects.Handler
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;
        public UpdateSubjectCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var res = await _dbContext.subjects.FirstOrDefaultAsync(x => x.SubjectId == request.SubjectId);
            if (res == null) throw new SubjectNotFoundException();
            res.SubjectName = request.SubjectName;

            _dbContext.subjects.Update(res);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
