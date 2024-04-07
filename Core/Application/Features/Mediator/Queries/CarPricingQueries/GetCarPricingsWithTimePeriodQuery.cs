using Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingsWithTimePeriodQuery : IRequest<List<GetCarPricingsWithTimePeriodQueryResult>>
	{
	}
}
