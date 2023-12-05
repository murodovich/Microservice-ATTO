using MediatR;
using University.Domain.Models;

namespace University.Application.UseCases.Groups.Queries
{
    public class GetGroupCommand : IRequest<List<Group>>
    {

    }
}
