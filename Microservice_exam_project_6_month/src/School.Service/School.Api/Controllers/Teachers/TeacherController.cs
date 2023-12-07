using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.Teachers.Commands;
using School.Application.UseCases.Teachers.Queries;

namespace School.Api.Controllers.Teachers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllTeacherSchool()
        {
            var result = await _mediator.Send(new GetAllTeacherQuery());
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateTeacherSchool(CreateTeacherCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
    }
}
