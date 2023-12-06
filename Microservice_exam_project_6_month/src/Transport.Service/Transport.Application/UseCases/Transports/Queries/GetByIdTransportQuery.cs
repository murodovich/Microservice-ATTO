using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Application.UseCases.Transports.Queries
{
    public class GetByIdTransportQuery : IRequest<Domain.Entities.Transports.Transport>
    {
        public int Id { get; set; }
    }
}
