using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.Subjects.Commands;
using School.Application.UseCases.Subjects.Queries;

namespace School.Api.Controllers.Subjects
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllSubjectSchool()
        {
            var result = await _mediator.Send(new GetAllSubjectQuery());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateSubjectSchool(CreateSubjectCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdSubjectSchool(int id)
        {
            var result = await _mediator.Send(new GetByIdSubjectQuery() { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateSubjectSchool(UpdateSubjectCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteSubjectSchool(int id)
        {
            await _mediator.Send(new DeleteSubjectCommand() { Id = id });
            return Ok("Deleted");
        }
    }
}
