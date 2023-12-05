using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.Dedlineis.Commands;
using University.Application.UseCases.Dedlineis.Queries;

namespace University.Api.Controllers.Dedlines
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DedlineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DedlineController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateDedline([FromForm] CreateDedlineCommand command)
        {

            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllDedline()
        {
            var res = await _mediator.Send(new GetAllDedlineQuery());
            return Ok(res);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateDedline(UpdateDedlineComman updateDedlineComman)
        {
            await _mediator.Send(updateDedlineComman);
            return Ok("Update Dedline");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteDedline(int id)
        {
            await _mediator.Send(new DeleteDedlineCommand { Id = id });
            return Ok("Deleted Dedline");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdDedline(int id)
        {
            var res = await _mediator.Send(new GetByIdDedlineQuery { Id = id });
            return Ok(res);
        }
    }
}
