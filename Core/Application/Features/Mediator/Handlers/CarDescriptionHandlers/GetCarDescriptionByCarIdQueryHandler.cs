using Application.Features.Mediator.Queries.CarDescriptionQueries;
using Application.Features.Mediator.Results.CarDescriptionResults;
using Application.Interfaces;
using Application.Interfaces.CarDescriptionInterfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;
        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarDescription(request.Id);
            return new GetCarDescriptionByCarIdQueryResult
            {
                CarDescriptionID = value.CarDescriptionID,
                CarID = value.CarID,
                Details = value.Details,
            };
        }
    }
}
