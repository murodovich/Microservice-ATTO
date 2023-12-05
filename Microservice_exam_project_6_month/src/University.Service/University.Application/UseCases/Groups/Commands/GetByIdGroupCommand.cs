using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Groups.Commands
{
    public class GetByIdGroupCommand : IRequest<Group>
    {
        public int Id { get; set; }
    }
}
