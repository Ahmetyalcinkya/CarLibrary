using Application.Features.Mediator.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewsByCarId(int id)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(values);
        }
    }
}
