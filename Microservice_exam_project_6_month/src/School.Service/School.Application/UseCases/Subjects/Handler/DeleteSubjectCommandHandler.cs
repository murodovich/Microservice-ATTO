using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Commands;
using School.Domain.Exceptions.Subjects;

namespace School.Application.UseCases.Subjects.Handler
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public DeleteSubjectCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.subjects.FirstOrDefaultAsync(x => x.SubjectId == request.Id);
            if (result == null) throw new SubjectNotFoundException();
            _context.subjects.Remove(result);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
