using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Absreactions;
using Transport.Application.UseCases.Drivers.Commands;
using Transport.Domain.Exceptions.Drivers;

namespace Transport.Application.UseCases.Drivers.Handlers
{
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly ITransportDBContext _dbContext;

        public UpdateDriverCommandHandler(ITransportDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.drivers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new DriverNotFoundException();

            result.DriveName = request.DriverName;
            result.LicenseNumber = request.LicenseNumber;
            result.TransportId = request.TransportId;

            _dbContext.drivers.Update(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
