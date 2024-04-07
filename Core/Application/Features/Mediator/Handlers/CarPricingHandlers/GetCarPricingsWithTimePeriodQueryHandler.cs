using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingsWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingsWithTimePeriodQuery, List<GetCarPricingsWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;
		public GetCarPricingsWithTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingsWithTimePeriodQueryResult>> Handle(GetCarPricingsWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingsWithTimePeriod();
			return values.Select(value => new GetCarPricingsWithTimePeriodQueryResult
			{
				Model = value.Model,
				ListCoverImageUrl = value.ListCoverImageUrl,
				DailyAmount = value.Amounts[0],
				WeeklyAmount = value.Amounts[1],
				MonthlyAmount = value.Amounts[2],
			}).ToList();
		}
	}
}
