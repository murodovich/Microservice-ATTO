using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCases.Transports.Commands;
using Transport.Application.UseCases.Transports.Queries;

namespace Transport.Api.Controllers.Transports
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllTransport()
        {
            var result = await _mediator.Send(new GetAllTransportQuery());
            return Ok(result);

        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateTransport([FromForm]CreateTransportCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdTransport(int Id)
        {
            var result = await _mediator.Send(new GetByIdTransportQuery() { Id = Id});
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTransport([FromForm]UpdateTransportCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTransport(int Id)
        {
            await _mediator.Send( new DeleteTransportCommand() { Id = Id });
            return Ok("Deleted");
        }
    }
}
