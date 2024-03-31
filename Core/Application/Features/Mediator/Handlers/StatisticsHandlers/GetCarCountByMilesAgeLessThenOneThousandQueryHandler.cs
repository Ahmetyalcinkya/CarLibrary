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
    public class GetCarCountByMilesAgeLessThenOneThousandQueryHandler : IRequestHandler<GetCarCountByMilesAgeLessThenOneThousandQuery, GetCarCountByMilesAgeLessThenOneThousandQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountByMilesAgeLessThenOneThousandQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByMilesAgeLessThenOneThousandQueryResult> Handle(GetCarCountByMilesAgeLessThenOneThousandQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByMilesAgeLessThenOneThousand();
            return new GetCarCountByMilesAgeLessThenOneThousandQueryResult
            {
                CarCountByMilesAgeLessThenOneThousand = value,
            };
        }
    }
}
