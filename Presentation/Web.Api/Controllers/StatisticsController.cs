using Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }
        [HttpGet("GetCarsAverageHourlyPrice")]
        public async Task<IActionResult> GetCarsAverageHourlyPrice()
        {
            var value = await _mediator.Send(new GetCarsAverageHourlyPriceQuery());
            return Ok(value);
        }
        [HttpGet("GetCarsAverageDailyPrice")]
        public async Task<IActionResult> GetCarsAverageDailyPrice()
        {
            var value = await _mediator.Send(new GetCarsAverageDailyPriceQuery());
            return Ok(value);
        }
        [HttpGet("GetCarsAverageWeeklyPrice")]
        public async Task<IActionResult> GetCarsAverageWeeklyPrice()
        {
            var value = await _mediator.Send(new GetCarsAverageWeeklyPriceQuery());
            return Ok(value);
        }
        [HttpGet("GetCarsAverageMonthlyPrice")]
        public async Task<IActionResult> GetCarsAverageMonthlyPrice()
        {
            var value = await _mediator.Send(new GetCarsAverageMonthlyPriceQuery());
            return Ok(value);
        }
        [HttpGet("GetAutoTransmissionCarsCount")]
        public async Task<IActionResult> GetAutoTransmissionCarsCount()
        {
            var value = await _mediator.Send(new GetAutoTransmissionCarsCountQuery());
            return Ok(value);
        }
        [HttpGet("GetMostPopularBrandName")]
        public async Task<IActionResult> GetMostPopularBrandName()
        {
            var value = await _mediator.Send(new GetMostPopularBrandNameQuery());
            return Ok(value);
        }
        [HttpGet("GetBlogTitleWithMostComments")]
        public async Task<IActionResult> GetBlogTitleWithMostComments()
        {
            var value = await _mediator.Send(new GetBlogTitleWithMostCommentsQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByMilesAgeLessThenOneThousand")]
        public async Task<IActionResult> GetCarCountByMilesAgeLessThenOneThousand()
        {
            var value = await _mediator.Send(new GetCarCountByMilesAgeLessThenOneThousandQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByE_Car")]
        public async Task<IActionResult> GetCarCountByE_Car()
        {
            var value = await _mediator.Send(new GetCarCountByE_CarQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(value);
        }
    }
}
