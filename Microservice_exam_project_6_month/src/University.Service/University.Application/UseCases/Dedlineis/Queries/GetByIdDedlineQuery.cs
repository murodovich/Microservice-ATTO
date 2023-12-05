using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Dedlineis.Queries
{
    public class GetByIdDedlineQuery : IRequest<Dedline>
    {
        public int Id { get; set; }

    }
}
