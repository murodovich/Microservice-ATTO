using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCases.Scheldules.Commands;
using Transport.Application.UseCases.Scheldules.Queries;

namespace Transport.Api.Controllers.Scheldule
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchelduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchelduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllScheldule()
        {
            var result = await _mediator.Send(new GetAllSchelduleQuery());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateScheldule([FromForm] CreateSchelduleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdScheldule(int Id) 
        {
            var result = await _mediator.Send(new GetByIdSchelduleQuery() { Id = Id });
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateScheldule([FromForm] UpdateSchelduleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteScheldule(int Id)
        {
            await _mediator.Send(new DeleteSchelduleCommand() { Id = Id });
            return Ok("Deleted");
        }
    }
}
