using Application.Constants;
using Application.Features.Mediatr.Events.Commands;
using Application.Features.Mediatr.Events.Handlers.Read;
using Application.Features.Mediatr.Events.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventList()
        {
            var values = await _mediator.Send(new GetAllEventQuery());
            return Ok(values);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var values = await _mediator.Send(new GetEventByIdQuery(id));
            return Ok(values);
        }
        [HttpGet("GetAllEventByUserId")]
        public async Task<IActionResult> GetAllEventByUserId(int userId)
        {
            var values = await _mediator.Send(new GetAllEventByUserIdQuery(userId));
            return Ok(values);
        }
        [HttpGet("GetAvailableEventsByUserId")]
        public async Task<IActionResult> GetAvailableEventsByUserId(int userId)
        {
            var values = await _mediator.Send(new GetAvailableEventsForUserQuery(userId));
            return Ok(values);
        }
        //[HttpGet("GetEventsByUserIdStatus/{userId}/{status}")]
        [HttpGet("GetEventsByUserIdStatus")]
        public async Task<IActionResult> GetEventsByUserIdStatus(int userId,string status)
        {
            var values = await _mediator.Send(new GetAllEventByUserIdStatusQuery(userId,status));
            return Ok(values);
        }

        [HttpGet("GetEventsCountByStatusAndUserId")]
        public async Task<IActionResult> GetEventsCountByStatusAndUserId(int userId)
        {
            var values = await _mediator.Send(new GetEventsCountByStatusAndUserIdQuery(userId));
            return Ok(values);
        }
        [HttpGet("GetAllPendingEventForAdmin")]
        public async Task<IActionResult> GetAllPendingEventForAdmin()
        {
            var values = await _mediator.Send(new GetAllPendingEventQuery());
            return Ok(values);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Event>.EntityAdded);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Event>.EntityUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveEvent(int id)
        {
            await _mediator.Send(new RemoveEventCommand(id));
            return Ok(Messages<Event>.EntityDeleted);
        }
    }
}
