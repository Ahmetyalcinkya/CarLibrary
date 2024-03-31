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
    public class GetBlogTitleWithMostCommentsQueryHandler : IRequestHandler<GetBlogTitleWithMostCommentsQuery, GetBlogTitleWithMostCommentsQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetBlogTitleWithMostCommentsQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleWithMostCommentsQueryResult> Handle(GetBlogTitleWithMostCommentsQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogTitleWithMostComments();
            return new GetBlogTitleWithMostCommentsQueryResult
            {
                BlogTitleWithMostComments = value,
            };
        }
    }
}
