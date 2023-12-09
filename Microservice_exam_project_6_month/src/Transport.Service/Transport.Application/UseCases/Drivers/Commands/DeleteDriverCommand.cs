using MediatR;
namespace Transport.Application.UseCases.Drivers.Commands
{
    public class DeleteDriverCommand : IRequest<bool>
    {
        public int  Id { get; set; }

    }
}
