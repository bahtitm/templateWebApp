using MediatR;
using Medicine.Application.Storages.Commands.CreateStorage;
using Medicine.Application.Storages.Commands.DeleteStorage;
using Medicine.Application.Storages.Commands.UpdateStorage;
using Medicine.Application.Storages.Commands.UpdateStorageVisibility;
using Medicine.Application.Storages.Queries.GetAll;
using Medicine.Application.Storages.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;

        public StorageController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }

        [PermissionRequirement(ClaimType.Storge, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetAllStorageQuery()));
        }

        [PermissionRequirement(ClaimType.Storge, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailStorageQuery(id)));
        }

        [PermissionRequirement(ClaimType.Storge, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStorageCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Storge, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStorageCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Storge, ClaimValue.Update)]
        [HttpPut("StorageVisibilityUpdate/{id}")]
        public async Task<IActionResult> StorageVisibilityUpdate(int id, [FromBody] UpdateStorageVisibilityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            var sucsess = authorizationService.AuthorizeAsync(User, id, "IsManager");
            if (sucsess.Result.Succeeded)
            {
                await mediator.Send(command);
                return NoContent();
            }
            return Forbid();
        }

        [PermissionRequirement(ClaimType.Storge, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteStorageCommand(id));
            return NoContent();
        }
    }
}
