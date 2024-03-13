using Application.Features.Mediator.Queries.BlogQueries;
using Application.Features.Mediator.Results.BlogResults;
using Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsAuthorByIdQueryHandler : IRequestHandler<GetBlogsAuthorByIdQuery, List<GetBlogsAuthorByIdQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetBlogsAuthorByIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBlogsAuthorByIdQueryResult>> Handle(GetBlogsAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetBlogsAuthorById(request.Id);
            return values.Select(value => new GetBlogsAuthorByIdQueryResult
            {
                AuthorID = value.AuthorID,
                BlogID = value.BlogID,
                AuthorName = value.Author.Name,
                AuthorDescription = value.Author.Description,
                AuthorImageUrl = value.Author.ImageUrl,
            }).ToList();

        }
    }
}
