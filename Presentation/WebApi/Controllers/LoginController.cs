using Application.Constants;
using Application.Features.Mediatr.Users.Queries;
using Application.Tools;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Index(GetUserByMailAndPasswordQuery query)
        {
            var user=await _mediator.Send(query);
            if(user.IsExist)
            {
                return Created("",JwtTokenGenerator.GenerateToken(user));
            }
            else
            {
                return BadRequest(Messages<User>.EntityCantMathes);
            }
        }
    }
}
