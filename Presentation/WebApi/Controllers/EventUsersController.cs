using Application.Constants;
using Application.Features.Mediatr.EventUsers.Commands;
using Application.Features.Mediatr.EventUsers.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventUserList()
        {
            var values = await _mediator.Send(new GetAllEventUserQuery());
            return Ok(values);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetEventUserById(int id)
        {
            var values = await _mediator.Send(new GetEventUserByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEventUser(CreateEventUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<EventUser>.EntityAdded);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEventUser(UpdateEventUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<EventUser>.EntityUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveEventUser(int id)
        {
            await _mediator.Send(new RemoveEventUserCommand(id));
            return Ok(Messages<EventUser>.EntityDeleted);
        }
    }
}
