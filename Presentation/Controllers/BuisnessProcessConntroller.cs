using MediatR;
using Medicine.Application.BuisnessProcessies.Commands.CreateBuisnessProcess;
using Medicine.Application.BuisnessProcessies.Commands.DeleteBuisnessProcess;
using Medicine.Application.BuisnessProcessies.Commands.UpdateBuisnessProcess;
using Medicine.Application.BuisnessProcessies.Queries.GetAll;
using Medicine.Application.BuisnessProcessies.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuisnessProcessConntroller : ControllerBase
    {

        private readonly IMediator mediator;
        public BuisnessProcessConntroller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.BuisnessProcess, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllBuisnessProcessQuery()));
        }

        [PermissionRequirement(ClaimType.BuisnessProcess, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailBuisnessProcessQuery(id)));
        }

        [PermissionRequirement(ClaimType.BuisnessProcess, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBuisnessProcessCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.BuisnessProcess, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBuisnessProcessCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.BuisnessProcess, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteBuisnessProcessCommand(id));
            return NoContent();
        }
    }
}
