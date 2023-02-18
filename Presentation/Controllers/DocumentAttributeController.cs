using MediatR;
using Medicine.Application.Attributes.Commands.CreateDocumentAttribute;
using Medicine.Application.Attributes.Commands.DeleteDocumentAttribute;
using Medicine.Application.Attributes.Commands.UpdateDocumentAttribute;
using Medicine.Application.Attributes.Queries.GetAll;
using Medicine.Application.Attributes.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentAttributeController : ControllerBase
    {
        private readonly IMediator mediator;
        public DocumentAttributeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllDocumentAttributeQuery()));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailDocumentAttributeQuery(id)));
        }


        [PermissionRequirement(ClaimType.Document, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDocumentAttributeCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDocumentAttributeCommand command)
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
            await mediator.Send(new DeleteDocumentAttributeCommand(id));
            return NoContent();
        }
    }
}
