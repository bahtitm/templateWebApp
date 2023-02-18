using MediatR;
using Medicine.Application.Users.Commands.CreateUser;
using Medicine.Application.Users.Commands.DeleteUser;
using Medicine.Application.Users.Commands.UpdateUser;
using Medicine.Application.Users.Queries.GetAll;
using Medicine.Application.Users.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.User, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllUserQuery()));
        }

        [PermissionRequirement(ClaimType.User, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailUserQuery(id)));
        }

        [PermissionRequirement(ClaimType.User, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.User, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.User, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}
