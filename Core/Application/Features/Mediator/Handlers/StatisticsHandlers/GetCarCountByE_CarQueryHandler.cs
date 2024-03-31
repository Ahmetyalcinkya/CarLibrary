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
    public class GetCarCountByE_CarQueryHandler : IRequestHandler<GetCarCountByE_CarQuery, GetCarCountByE_CarQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountByE_CarQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByE_CarQueryResult> Handle(GetCarCountByE_CarQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByE_Car();
            return new GetCarCountByE_CarQueryResult { CarCountByE_Car = value };
        }
    }
}
