using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(value => new GetCarQueryResult
            {
                BrandID = value.BrandID,
                CarCoverImageUrl = value.CarCoverImageUrl,
                CarID = value.CarID,
                Fuel = value.Fuel,
                ListCoverImageUrl = value.ListCoverImageUrl,
                Luggage=value.Luggage,
                MileAge=value.MileAge,
                Model=value.Model,
                Seat=value.Seat,
                Transmission=value.Transmission,
            }).ToList();
        }
    }
}
