using Application.Features.Mediator.Queries.BlogQueries;
using Application.Features.Mediator.Results.BlogResults;
using Application.Interfaces;
using Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLastThreeBlogsWithAuthorsQueryHandler : IRequestHandler<GetLastThreeBlogsWithAuthorsQuery, List<GetLastThreeBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetLastThreeBlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastThreeBlogsWithAuthorsQueryResult>> Handle(GetLastThreeBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLastThreeBlogsWithAuthors();
            return values.Select(value => new GetLastThreeBlogsWithAuthorsQueryResult
            {
                AuthorID = value.AuthorID,
                BlogID = value.BlogID,
                CategoryID = value.CategoryID,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                Title = value.Title,
                AuthorName = value.Author.Name
            }).ToList();
        }
    }
}
