using MediatR;

namespace University.Application.UseCases.Dedlineis.Commands
{
    public class DeleteDedlineCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
