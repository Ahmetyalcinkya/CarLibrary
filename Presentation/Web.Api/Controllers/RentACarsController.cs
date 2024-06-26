﻿using Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentACarsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public RentACarsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetRentACarListByLocation(int locationID, bool isAvailable)
		{
			GetRentACarQuery query = new GetRentACarQuery 
			{
				LocationID = locationID,
				isAvailable = isAvailable
			};
			var values = await _mediator.Send(query);
			return Ok(values);
		}
	}
}
