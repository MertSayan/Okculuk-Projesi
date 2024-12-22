using Application.Constants;
using Application.Features.Mediatr.Users.Commands;
using Application.Features.Mediatr.Users.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var values = await _mediator.Send(new GetAllUserQuery());
            return Ok(values);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var values = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(values);
        }
        [HttpGet("ByIdForAdmin")]
        public async Task<IActionResult> GetUserByIdForAdmin(int id)
        {
            var values = await _mediator.Send(new GetUserByIdForAdminQuery(id));
            return Ok(values);
        }

        [HttpGet("GetAllUserByEventId")]
        public async Task<IActionResult> GetAllUserByEventId(int eventId)
        {
            var values = await _mediator.Send(new GetAllUserByEventIdQuery(eventId));
            return Ok(values);
        }
        [HttpGet("GetAllUserForVisibleEvent")]
        public async Task<IActionResult> GetAllUserForVisibleEvent()
        {
            var values = await _mediator.Send(new GetAllUserForVisibleEventQuery());
            return Ok(values);
        }
        [HttpGet("GetAllUserByRegionName")]
        public async Task<IActionResult> GetAllUserByRegionId(string RegionName)
        {
            var values = await _mediator.Send(new GetAllUserByRegionIdQuery(RegionName));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityAdded);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }
        [HttpPut("UpdateForAdmin")]
        public async Task<IActionResult> UpdateForAdmin(UpdateUserByAdminCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok(Messages<User>.EntityDeleted);
        }
    }
}
