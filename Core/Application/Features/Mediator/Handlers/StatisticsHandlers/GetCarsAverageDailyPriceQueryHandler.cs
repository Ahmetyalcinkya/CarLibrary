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
    public class GetCarsAverageDailyPriceQueryHandler : IRequestHandler<GetCarsAverageDailyPriceQuery, GetCarsAverageDailyPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarsAverageDailyPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarsAverageDailyPriceQueryResult> Handle(GetCarsAverageDailyPriceQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarsAverageDailyPrice();
            return new GetCarsAverageDailyPriceQueryResult
            {
                AverageDailyPrice = value,
            };
        }
    }
}
