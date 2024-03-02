using Application.Features.Mediator.Queries.ServiceQueries;
using Application.Features.Mediator.Results.ServiceResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;
        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(value => new GetServiceQueryResult
            {
                Description = value.Description,
                IconUrl = value.IconUrl,
                ServiceID = value.ServiceID,
                Title = value.Title,
            }).ToList();
        }
    }
}
