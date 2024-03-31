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
    public class GetCarsAverageHourlyPriceQueryHandler : IRequestHandler<GetCarsAverageHourlyPriceQuery, GetCarsAverageHourlyPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarsAverageHourlyPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarsAverageHourlyPriceQueryResult> Handle(GetCarsAverageHourlyPriceQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarsAverageHourlyPrice();
            return new GetCarsAverageHourlyPriceQueryResult
            {
                AverageHourlyPrice = value,
            };
        }
    }
}
