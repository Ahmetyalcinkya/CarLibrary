using Application.Features.Mediator.Queries.AppUserQueries;
using Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
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
        public async Task<IActionResult> Index(CheckAppUserQuery query)
        {
            var values = await _mediator.Send(query);
            if(values.isExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(values));
            }

            return BadRequest("Wrong Username or Password!");
        }
    }
}
