using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Application.Interfaces.CarInterfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLastFiveCarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetLastFiveCarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetLastFiveCarsWithBrandQueryResult> Handle()
        {
            var values =  _repository.GetLastFiveCarsWithBrand();
            return values.Select(value => new GetLastFiveCarsWithBrandQueryResult
            {
                BrandID = value.BrandID,
                BrandName = value.Brand.Name,
                CarCoverImageUrl = value.CarCoverImageUrl,
                CarID = value.CarID,
                Fuel = value.Fuel,
                ListCoverImageUrl = value.ListCoverImageUrl,
                Luggage = value.Luggage,
                MileAge = value.MileAge,
                Model = value.Model,
                Seat = value.Seat,
                Transmission = value.Transmission,
            }).ToList();
        }
    }
}
