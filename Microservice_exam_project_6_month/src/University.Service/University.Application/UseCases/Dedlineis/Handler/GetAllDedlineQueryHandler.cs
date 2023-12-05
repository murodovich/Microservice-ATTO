using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Dedlineis.Queries;
using University.Domain.Exceptions.Dedlineis;
using University.Domain.Models;

namespace University.Application.UseCases.Dedlineis.Handler
{
    public class GetAllDedlineQueryHandler : IRequestHandler<GetAllDedlineQuery, List<Dedline>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetAllDedlineQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dedline>> Handle(GetAllDedlineQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.dededlines.ToListAsync();
            if (result == null) throw new DedlineNotFoundException();
            return result;
        }
    }
}
