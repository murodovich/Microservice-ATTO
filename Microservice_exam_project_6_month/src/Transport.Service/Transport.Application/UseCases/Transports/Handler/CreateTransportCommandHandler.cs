using MediatR;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Transports.Commands;

namespace Transport.Application.UseCases.Transports.Handler
{
    public class CreateTransportCommandHandler : IRequestHandler<CreateTransportCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public CreateTransportCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
