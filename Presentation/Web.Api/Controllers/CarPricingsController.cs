using Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPricingsController : ControllerBase
	{
		private IMediator _mediator;
		public CarPricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllCarPricingWithCars()
		{
			var values = await _mediator.Send(new GetCarPricingWithCarsQuery());
			return Ok(values);
		}
	}
}
