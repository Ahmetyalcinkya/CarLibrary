using Application.Features.Mediator.Queries.RentACarQueries;
using Application.Features.Mediator.Results.RentACarResults;
using Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.RentACarHandlers
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{
		private readonly IRentACarRepository _repository;
		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetByFilterAsync(value => value.LocationID == request.LocationID && value.isAvailable == true);
			return values.Select(value => new GetRentACarQueryResult
			{
				CarID = value.CarID,
				Brand = value.Car.Brand.Name,
				Model = value.Car.Model,
				ListCoverImageUrl = value.Car.ListCoverImageUrl,
			}).ToList();
		}
	}
}
