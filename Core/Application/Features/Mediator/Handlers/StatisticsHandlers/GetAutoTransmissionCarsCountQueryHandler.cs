using Application.Features.Mediator.Queries.StatisticsQueries;
using Application.Features.Mediator.Results.StatisticsResults;
using Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAutoTransmissionCarsCountQueryHandler : IRequestHandler<GetAutoTransmissionCarsCountQuery, GetAutoTransmissionCarsCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetAutoTransmissionCarsCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAutoTransmissionCarsCountQueryResult> Handle(GetAutoTransmissionCarsCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAutoTransmissionCarsCount();
            return new GetAutoTransmissionCarsCountQueryResult
            {
                AutoTransmissionCarsCount = value,
            };
        }
    }
}
