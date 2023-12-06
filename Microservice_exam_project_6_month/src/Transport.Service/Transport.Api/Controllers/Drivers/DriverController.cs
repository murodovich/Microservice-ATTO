using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCases.Drivers.Commands;
using Transport.Application.UseCases.Drivers.Queries;

namespace Transport.Api.Controllers.Drivers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllDriver()
        {
            var result = await _mediator.Send(new GetAllDriverQuery());
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateDriver(CreateDriverCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok("Created Driver");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdDriver(int Id)
        {
            var result = await _mediator.Send(new GetByIdDriverQuery() { Id = Id});
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateDriver(UpdateDriverCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated Driver");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteDriver(int Id)
        { 
            await _mediator.Send(new DeleteDriverCommand() { Id = Id });
            return Ok("Deleted Driver");
        }
    }
}
