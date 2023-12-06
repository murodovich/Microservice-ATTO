using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Domain.Entities.Drivers;

namespace Transport.Application.UseCases.Drivers.Queries
{
    public class GetAllDriverQuery : IRequest<List<Driver>>
    {
    }
}
