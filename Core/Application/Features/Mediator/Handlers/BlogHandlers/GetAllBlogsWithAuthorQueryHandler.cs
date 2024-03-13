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
	public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;
		public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetAllBlogsWithAuthor();
			return values.Select(value => new GetAllBlogsWithAuthorQueryResult
			{
				AuthorID = value.AuthorID,
				AuthorName = value.Author.Name,
				BlogID = value.BlogID,
				CategoryID = value.CategoryID,
				//CategoryName = value.Category.Name,
				CoverImageUrl = value.CoverImageUrl,
				CreatedDate = value.CreatedDate,
				Title = value.Title,
				Description = value.Description,
				AuthorDescription = value.Author.Description,
				AuthorImageUrl = value.Author.ImageUrl,
			}).ToList();
		}
	}
}
