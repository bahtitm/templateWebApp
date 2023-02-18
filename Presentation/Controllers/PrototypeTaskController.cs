using MediatR;
using Medicine.Application.PrototypeTasks.Commands.ClosePrototypeTask;
using Medicine.Application.PrototypeTasks.Commands.DeletePrototypeTask;
using Medicine.Application.PrototypeTasks.Queries.GetAll;
using Medicine.Application.PrototypeTasks.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrototypeTaskController : ControllerBase
    {
        private readonly IMediator mediator;
        public PrototypeTaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.PrototypeTask, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllPrototypeTasksQuery()));
        }

        [PermissionRequirement(ClaimType.PrototypeTask, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailPrototypeTaskQuery(id)));
        }

        [PermissionRequirement(ClaimType.PrototypeTask, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeletePrototypeTaskCommand(id));
            return NoContent();
        }

        [PermissionRequirement(ClaimType.PrototypeTask, ClaimValue.Update)]
        [HttpPost("close/{id}")]
        public async Task<IActionResult> Close(int id)
        {
            await mediator.Send(new ClosePrototypeTaskCommand(id));
            return NoContent();
        }
    }
}
