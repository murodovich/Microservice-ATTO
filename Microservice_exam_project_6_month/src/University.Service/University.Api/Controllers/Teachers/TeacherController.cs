using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Dtos;
using University.Application.UseCases.Teachers.Commands;
using University.Application.UseCases.Teachers.Queries;

namespace University.Api.Controllers.Teachers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllTeacher()
        {
            var result = await _mediator.Send(new GetAllTeacherQuerie());
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateTechar(CreateTeacherCommand teacher)
        {
            await _mediator.Send(teacher);
            return Ok("Created Teacher");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdTeacher(int id)
        {
            var result = new GetByIdTeacherQuerie()
            {
                Id = id
            };
            var res = await _mediator.Send(result);
            return Ok(res);

        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeacher(UpdateTeacherCommand command)
        {
            await _mediator.Send(command);
            return Ok("Teacher Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTeacher(int id)
        {
            var result = new DeleteTeacherCommand() { Id = id };
            await _mediator.Send(result);
            return Ok("Teacher Deleted");
        }
    }
}
