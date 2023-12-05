using MediatR;
using University.Application.Absreactions;
using University.Application.UseCases.Subjects.Commands;
using University.Domain.Models;

namespace University.Application.UseCases.Subjects.Handler
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public CreateSubjectCommandHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var result = new Subject()
            {
                SubjectName = request.SubjectName
            };
            await _dbContext.subjects.AddAsync(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
