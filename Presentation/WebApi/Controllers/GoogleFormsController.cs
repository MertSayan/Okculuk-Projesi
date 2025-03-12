using Application.Constants;
using Application.Features.Mediatr.GoogleForms.Commands;
using Application.Features.Mediatr.GoogleForms.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleFormsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoogleFormsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForm()
        {
            var values = await _mediator.Send(new GetGoogleFormQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateForm(CreateGoogleFormCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<GoogleForm>.EntityAdded);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteForm()
        {
            await _mediator.Send(new DeleteGoogleFormCommand());
            return Ok(Messages<GoogleForm>.EntityDeleted);
        }
    }
}
