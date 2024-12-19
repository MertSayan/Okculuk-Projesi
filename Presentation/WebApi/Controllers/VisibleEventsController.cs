using Application.Constants;
using Application.Features.Mediatr.VisibleEvents.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisibleEventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VisibleEventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisibleEvent(CreateVisibleEventCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Role>.EntityAdded);
        }
    }
}
