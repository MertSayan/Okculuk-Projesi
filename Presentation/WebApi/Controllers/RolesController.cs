using Application.Constants;
using Application.Features.Mediatr.Roles.Commands;
using Application.Features.Mediatr.Roles.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleList()
        {
            var values = await _mediator.Send(new GetAllRoleQuery());
            return Ok(values);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var values = await _mediator.Send(new GetRoleByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Role>.EntityAdded);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Role>.EntityUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRole(int id)
        {
            await _mediator.Send(new RemoveRoleCommand(id));
            return Ok(Messages<Role>.EntityDeleted);
        }
    }
}
