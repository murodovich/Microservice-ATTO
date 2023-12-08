using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.Subjects.Commands;
using University.Application.UseCases.Subjects.Queries;

namespace University.Api.Controllers.Subjects
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
        public async ValueTask<IActionResult> GetAllSubject()
        {
            var res = await _mediator.Send(new GetAllSubjectQuery());
            return Ok(res);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateSubject([FromForm]CreateSubjectCommand createSubject)
        {
            
            await _mediator.Send(createSubject);
            return Ok("Created Subject");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdSubject(int Id)
        {
            var res = new GetByIdSubjectQuery()
            {
                Id = Id
            };
            var result = await _mediator.Send(res);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> Update([FromForm]UpdateSubjectCommand updateSubject)
        {
            await _mediator.Send(updateSubject);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteSubject(int Id)
        {
            var res = new DeleteSubjectCommand()
            {
                Id = Id
            };
            await _mediator.Send(res);
            return Ok("Deleted");
        }
    }
}
