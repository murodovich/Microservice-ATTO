using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.Subjects.Commands;
using University.Application.UseCases.Subjects.Queries;

namespace University.Api.Controllers
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
        public async ValueTask<IActionResult> CreateSubject(CreateSubjectCommand createSubject) 
        {
            var res = new CreateSubjectCommand()
            {
                SubjectName = createSubject.SubjectName,
            };
            await _mediator.Send(res);
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
        public async ValueTask<IActionResult> Update(UpdateSubjectCommand updateSubject)
        {
            var res = new UpdateSubjectCommand()
            {
                SubjectId = updateSubject.SubjectId,               
                SubjectName = updateSubject.SubjectName,
            };
            await _mediator.Send(res);
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
