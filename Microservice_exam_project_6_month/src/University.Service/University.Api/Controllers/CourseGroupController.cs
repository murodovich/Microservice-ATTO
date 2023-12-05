using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.CourseGroups.Commands;
using University.Application.UseCases.CourseGroups.Queries;

namespace University.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCourseGroup()
        {
            var res = await _mediator.Send(new GetAllCourseGroupQuery());
            return Ok(res);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCourseGroup(CreateCourseGroupCommand command)
        {
            var res = new CreateCourseGroupCommand()
            {
                GroupId = command.GroupId,
                CourseId = command.CourseId,
            };
            await _mediator.Send(res);
            return Ok("Created CourseGroup");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdCourseGroup(int id)
        {
            var res = new GetByIdCourseGroupQuery()
            {
                Id = id
            };
            var result = await _mediator.Send(res);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCourseGroup(UpdateCourseGroupCommand command)
        {
            var res = new UpdateCourseGroupCommand()
            {
                GroupId = command.GroupId,
                CourseId = command.CourseId,
            };
            await _mediator.Send(res);
            return Ok("Updated CourseGroup");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCourseGroup(int id)
        {
            var res = new DeleteCourseGroupCommand()
            {
                Id = id
            };
            await _mediator.Send(res);
            return Ok("Deleted CourseGroup");
        }
    }
}
