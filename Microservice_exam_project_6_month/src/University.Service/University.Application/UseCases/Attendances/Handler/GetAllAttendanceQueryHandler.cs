using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Absreactions;
using University.Application.UseCases.Attendances.Queries;
using University.Domain.Models;

namespace University.Application.UseCases.Attendances.Handler
{
    public class GetAllAttendanceQueryHandler : IRequestHandler<GetAllAttandanceQuery, List<Attendance>>
    {
        private readonly IUniversityDBContext _dbContext;

        public GetAllAttendanceQueryHandler(IUniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Attendance>> Handle(GetAllAttandanceQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.attendances.ToListAsync();
            return result;
        }
    }
}
