using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Dedlineis.Queries
{
    public class GetAllDedlineQuery : IRequest<List<Dedline>>
    {
    }
}
