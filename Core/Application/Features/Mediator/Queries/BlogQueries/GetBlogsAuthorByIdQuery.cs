using Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogsAuthorByIdQuery : IRequest<List<GetBlogsAuthorByIdQueryResult>>
    {
        public int Id { get; set; }
        public GetBlogsAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
