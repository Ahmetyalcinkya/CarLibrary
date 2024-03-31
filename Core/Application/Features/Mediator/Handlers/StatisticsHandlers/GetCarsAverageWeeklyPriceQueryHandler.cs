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
    public class GetCarsAverageWeeklyPriceQueryHandler : IRequestHandler<GetCarsAverageWeeklyPriceQuery, GetCarsAverageWeeklyPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarsAverageWeeklyPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarsAverageWeeklyPriceQueryResult> Handle(GetCarsAverageWeeklyPriceQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarsAverageWeeklyPrice();
            return new GetCarsAverageWeeklyPriceQueryResult
            {
                AverageWeeklyPrice = value,
            };
        }
    }
}
