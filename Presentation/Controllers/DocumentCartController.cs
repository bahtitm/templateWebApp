using MediatR;
using Medicine.Application.DocumentCarts.Commands.CreateDocumentCart;
using Medicine.Application.DocumentCarts.Commands.DeleteDocumentCart;
using Medicine.Application.DocumentCarts.Commands.UpdateDocumentCart;
using Medicine.Application.DocumentCarts.Queries.GetAll;
using Medicine.Application.DocumentCarts.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentCartController : ControllerBase
    {
        private readonly IMediator mediator;
        public DocumentCartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllDocumentCartQuery()));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailDocumentCartQuery(id)));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDocumentCartCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDocumentCartCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteDocumentCartCommand(id));
            return NoContent();
        }
    }
}
