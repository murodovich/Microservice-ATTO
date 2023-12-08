using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Application.UseCases.Teachers.Commands;
using School.Application.UseCases.Teachers.Queries;

namespace School.Api.Controllers.Teachers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public TeacherController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllTeacherSchool()
        {
            var cashe = _memoryCache.Get("GetAll");
            if (cashe == null)
            {
                var result = await _mediator.Send(new GetAllTeacherQuery());
                _memoryCache.Set("GetAll",result);
            }
            return Ok(_memoryCache.Get("GetAll"));
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateTeacherSchool(CreateTeacherCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdTeacherSchool(int Id)
        {
            var cashe = _memoryCache.Get(Id);
            if (cashe == null)
            {
                var result = await _mediator.Send(new GetByIdTeacherQuery() { Id = Id });
                _memoryCache.Set(Id,result);
            }
            return Ok(_memoryCache.Get(Id));
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTacherSchool(UpdateTeacherCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTeacherSchool(int Id)
        {
            await _mediator.Send(new DeleteTeacherCommand() { Id = Id });
            return Ok("Deleted");
        }
    }
}
