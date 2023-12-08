using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.UseCases.Attendances.Commands;
using University.Application.UseCases.Attendances.Queries;

namespace University.Api.Controllers.Attendances
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttandanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttandanceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAttendance()
        {
            var res = await _mediator.Send(new GetAllAttandanceQuery());
            return Ok(res);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAttendance([FromForm]CreateAttendanceCommand command)
        {
            var result = new CreateAttendanceCommand()
            {
                Attendances = command.Attendances,
                StudentId = command.StudentId,
                LessonId = command.LessonId,

            };
            await _mediator.Send(result);
            return Ok("Created Attendance");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAttendance(int id)
        {
            var res = new GetByIdAttendanceQuery()
            {
                Id = id
            };
            var result = await _mediator.Send(res);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateAttandance([FromForm]UpdateAttendanceCommand command)
        {
            var result = new UpdateAttendanceCommand()
            {
                AttendanceId = command.AttendanceId,
                StudentId = command.StudentId,
                LessonId = command.LessonId,
                Attendances = command.Attendances
            };
            await _mediator.Send(result);
            return Ok("Updated Attendance");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAttendance(int id)
        {
            await _mediator.Send(new DeleteAttendanceCommand() { Id = id });
            return Ok("Deleted Attendance");
        }
    }
}
