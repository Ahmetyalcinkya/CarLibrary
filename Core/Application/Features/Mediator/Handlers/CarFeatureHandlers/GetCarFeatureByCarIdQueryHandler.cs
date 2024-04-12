using Application.Features.Mediator.Queries.CarFeatureQueries;
using Application.Features.Mediator.Results.CarFeatureResults;
using Application.Interfaces;
using Application.Interfaces.CarFeatureInterfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarFeatureByCarID(request.Id);
            return values.Select(values => new GetCarFeatureByCarIdQueryResult
            {
                CarFeatureID = values.CarFeatureID,
                FeatureID = values.FeatureID,
                isAvailable = values.isAvailable,
                FeatureName = values.Features.Name
            }).ToList();
        }
    }
}
