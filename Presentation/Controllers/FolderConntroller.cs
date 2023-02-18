using MediatR;
using Medicine.Application.Folders.Commands.CreateFolder;
using Medicine.Application.Folders.Commands.DeleteFolder;
using Medicine.Application.Folders.Commands.UpdateFolder;
using Medicine.Application.Folders.Queries.GetAll;
using Medicine.Application.Folders.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderConntroller : ControllerBase
    {
        private readonly IMediator mediator;
        public FolderConntroller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.Folder, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllFolderQuery()));
        }

        [PermissionRequirement(ClaimType.Folder, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailFolderQuery(id)));
        }

        [PermissionRequirement(ClaimType.Folder, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFolderCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Folder, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateFolderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Folder, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteFolderCommand(id));
            return NoContent();
        }
    }
}
