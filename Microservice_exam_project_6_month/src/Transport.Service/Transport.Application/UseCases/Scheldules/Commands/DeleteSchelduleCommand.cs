using MediatR;

namespace Transport.Application.UseCases.Scheldules.Commands
{
    public class DeleteSchelduleCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
