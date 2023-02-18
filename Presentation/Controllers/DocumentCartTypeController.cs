using MediatR;
using Medicine.Application.DocumentCartTypes.Commands.CreateDocumentCartType;
using Medicine.Application.DocumentCartTypes.Commands.DeleteDocumentCartType;
using Medicine.Application.DocumentCartTypes.Commands.UpdateDocumentCartType;
using Medicine.Application.DocumentCartTypes.Queries.GetAll;
using Medicine.Application.DocumentCartTypes.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentCartTypeController : ControllerBase
    {
        private readonly IMediator mediator;
        public DocumentCartTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllDocumentCartTypeQuery()));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailDocumentCartTypeQuery(id)));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDocumentCartTypeCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDocumentCartTypeCommand command)
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
            await mediator.Send(new DeleteDocumentCartTypeCommand(id));
            return NoContent();
        }
    }
}
