using MediatR;
using Medicine.Application.Groups.Commands.CreateUserGroup;
using Medicine.Application.Groups.Commands.DeleteUserGroup;
using Medicine.Application.Groups.Commands.UpdateUserGroup;
using Medicine.Application.Groups.Queries.GetAll;
using Medicine.Application.Groups.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserGroupController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.UserGroup, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllUserGroupQuery()));
        }

        [PermissionRequirement(ClaimType.UserGroup, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailUserGroupQuery(id)));
        }

        [PermissionRequirement(ClaimType.UserGroup, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserGroupCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.UserGroup, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserGroupCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.UserGroup, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteUserGroupCommand(id));
            return NoContent();
        }
    }
}
