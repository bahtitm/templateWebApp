﻿using MediatR;
using Medicine.Application.Permissions.Commands.CreatePermission;
using Medicine.Application.Permissions.Commands.DeletePermission;
using Medicine.Application.Permissions.Commands.UpdatePermission;
using Medicine.Application.Permissions.Queries.GetAll;
using Medicine.Application.Permissions.Queries.GetDetail;
using Medicine.Authorization.Attributes;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator mediator;
        public PermissionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [PermissionRequirement(ClaimType.RolePremission, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllPermissionQuery()));
        }

        [PermissionRequirement(ClaimType.RolePremission, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailPermissionQuery(id)));
        }

        [PermissionRequirement(ClaimType.RolePremission, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePermissionCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.RolePremission, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePermissionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [PermissionRequirement(ClaimType.RolePremission, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeletePermissionCommand(id));
            return NoContent();
        }
    }
}
