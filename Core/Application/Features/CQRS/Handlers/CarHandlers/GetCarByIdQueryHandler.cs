using Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarID = value.CarID,
                BrandID = value.BrandID,
                Model = value.Model,
                ListCoverImageUrl = value.ListCoverImageUrl,
                MileAge = value.MileAge,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Luggage = value.Luggage,
                Fuel = value.Fuel,
                CarCoverImageUrl = value.CarCoverImageUrl,
            };
        }
    }
}
