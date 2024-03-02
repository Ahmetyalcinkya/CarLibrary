using Application.Features.Mediator.Queries.PricingQueries;
using Application.Features.Mediator.Results.PricingResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;
        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        async Task<List<GetPricingQueryResult>> IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>.Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(value => new GetPricingQueryResult
            {
                Name = value.Name,
                PricingID = value.PricingID,
            }).ToList();
        }
    }
}
