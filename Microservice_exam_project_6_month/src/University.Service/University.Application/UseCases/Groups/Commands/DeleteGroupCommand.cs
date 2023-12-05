using MediatR;

namespace University.Application.UseCases.Groups.Commands
{
    public class DeleteGroupCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
