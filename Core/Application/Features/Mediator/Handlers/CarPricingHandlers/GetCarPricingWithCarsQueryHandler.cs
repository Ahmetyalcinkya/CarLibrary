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
	public class GetCarPricingWithCarsQueryHandler : IRequestHandler<GetCarPricingWithCarsQuery, List<GetCarPricingWithCarsQueryResult>>
	{
		private readonly ICarPricingRepository _repository;
		public GetCarPricingWithCarsQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingsWithCars();
			return values.Select(value => new GetCarPricingWithCarsQueryResult
			{
				Amount = value.Amount,
				Brand = value.Car.Brand.Name,
				CarPricingID = value.CarPricingID,
				ListCoverImageUrl = value.Car.ListCoverImageUrl,
				Model = value.Car.Model
			}).ToList();
		}
	}
}
