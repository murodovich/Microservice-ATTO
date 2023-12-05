using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Dedlineis.Queries;
using University.Domain.Exceptions.Dedlineis;
using University.Domain.Models;

namespace University.Application.UseCases.Dedlineis.Handler
{
    public class GetByIdDedlineQueryHandler : IRequestHandler<GetByIdDedlineQuery, Dedline>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetByIdDedlineQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dedline> Handle(GetByIdDedlineQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.dededlines.FirstOrDefaultAsync(x => x.DedlineId == request.Id);
            if (result == null) throw new DedlineNotFoundException();
            return result;
        }
    }
}
