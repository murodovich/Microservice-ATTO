using MediatR;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Drivers.Commands;
using Transport.Domain.Entities.Drivers;

namespace Transport.Application.UseCases.Drivers.Handlers
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public CreateDriverCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = new Driver()
            {
                DriveName = request.DriverName,
                LicenseNumber = request.LicenseNumber,
                TransportId = request.TransportId,
            };

            await _dbContext.drivers.AddAsync(driver);

            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
