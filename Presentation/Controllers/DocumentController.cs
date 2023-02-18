using MediatR;
using Medicine.Application.Documents.Commands.CreateDocument;
using Medicine.Application.Documents.Commands.DeleteDocument;
using Medicine.Application.Documents.Commands.UpdateDocument;
using Medicine.Application.Documents.Commands.UploadDocumentFile;
using Medicine.Application.Documents.Queries.GetAll;
using Medicine.Application.Documents.Queries.GetAllDocumentFile;
using Medicine.Application.Documents.Queries.GetDetail;
using Medicine.Application.Documents.Queries.GetFile;
using Medicine.Application.Documents.Queries.GetSearchedDocument;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator mediator;
        public DocumentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllDocumentQuery()));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet("search")]
        public async Task<IActionResult> Search(string search)
        {

            return Ok(await mediator.Send(new GetSearchedDocumentQuery(search)));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailDocumentQuery(id)));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet("DocumentFiles/{documentId}")]
        public async Task<IActionResult> DocumentFiles(int documentId)
        {

            return Ok(await mediator.Send(new GetAllDocumentFileQuery(documentId)));
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Read)]
        [HttpGet("GetFile/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var datasource = await mediator.Send(new GetFileQuery(id));
            return File(datasource.File, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", datasource.Name);
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDocumentCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Create)]
        [HttpPost("file")]
        public async Task<IActionResult> Upload([FromForm] UploadDocumentFileCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.Document, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDocumentCommand command)
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
            await mediator.Send(new DeleteDocumentCommand(id));
            return NoContent();
        }
    }
}
