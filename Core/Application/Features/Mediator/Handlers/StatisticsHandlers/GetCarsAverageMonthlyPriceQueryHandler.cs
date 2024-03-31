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
    public class GetCarsAverageMonthlyPriceQueryHandler : IRequestHandler<GetCarsAverageMonthlyPriceQuery, GetCarsAverageMonthlyPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarsAverageMonthlyPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarsAverageMonthlyPriceQueryResult> Handle(GetCarsAverageMonthlyPriceQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarsAverageMonthlyPrice();
            return new GetCarsAverageMonthlyPriceQueryResult
            {
                AverageMonthlyPrice = value,
            };
        }
    }
}
