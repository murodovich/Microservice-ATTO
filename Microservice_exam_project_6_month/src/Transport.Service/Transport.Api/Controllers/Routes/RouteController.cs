using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCases.Routes.Commands;
using Transport.Application.UseCases.Routes.Queries;

namespace Transport.Api.Controllers.Routes
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async ValueTask<IActionResult> GetAllRoute()
        {          
            var res = await _mediator.Send(new GetAllRouteQuery());
            return Ok(res);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateRoute([FromForm] CreateRouteCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created Route");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdRoute(int Id)
        {
            var route = new GetByIdRouteQuery()
            {
                Id = Id
            };
            var result = await _mediator.Send(route);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateRoute([FromForm] UpdateRouteCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated Route");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteRoute(int Id)
        {
            await _mediator.Send(new DeleteRouteCommand() { Id = Id});
            return Ok("Deleted Route");
        }
    }
}
