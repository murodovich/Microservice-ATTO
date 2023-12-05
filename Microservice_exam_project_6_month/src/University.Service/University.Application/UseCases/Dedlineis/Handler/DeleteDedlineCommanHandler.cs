using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Dedlineis.Commands;
using University.Domain.Exceptions.Dedlineis;

namespace University.Application.UseCases.Dedlineis.Handler
{
    public class DeleteDedlineCommanHandler : IRequestHandler<DeleteDedlineCommand, bool>
    {
        private readonly IUniversityDBContext _dbContext;

        public DeleteDedlineCommanHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteDedlineCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.dededlines.FirstOrDefaultAsync(x => x.DedlineId == request.Id);
            if (result == null) throw new DedlineNotFoundException();
            _dbContext.dededlines.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
