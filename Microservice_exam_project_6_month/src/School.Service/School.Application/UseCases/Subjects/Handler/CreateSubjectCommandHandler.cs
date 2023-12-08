using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Commands;
using School.Domain.Entities.Subjects;

namespace School.Application.UseCases.Subjects.Handler
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateSubjectCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var result = new Subject()
            {
                Name = request.Name,
            };
            await _context.subjects.AddAsync(result);

            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
