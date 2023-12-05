using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Attendances.Queries
{
    public class GetAllAttandanceQuery : IRequest<List<Attendance>>
    {
    }
}
