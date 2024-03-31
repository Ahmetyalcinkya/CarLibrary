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
    public class GetMostPopularBrandNameQueryHandler : IRequestHandler<GetMostPopularBrandNameQuery, GetMostPopularBrandNameQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetMostPopularBrandNameQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMostPopularBrandNameQueryResult> Handle(GetMostPopularBrandNameQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetMostPopularBrandName();
            return new GetMostPopularBrandNameQueryResult
            {
                MostPopularBrandName = value,
            };
        }
    }
}
