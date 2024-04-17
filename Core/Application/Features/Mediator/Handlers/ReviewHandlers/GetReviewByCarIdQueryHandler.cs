using Application.Features.Mediator.Queries.ReviewQueries;
using Application.Features.Mediator.Results.ReviewResults;
using Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;
        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarReviewsByCarId(request.Id);
            return values.Select(value => new GetReviewByCarIdQueryResult
            {
                CarID = value.CarID,
                ReviewID = value.ReviewID,
                Comment = value.Comment,
                CustomerImage = value.CustomerImage,
                CustomerName = value.CustomerName,
                Rating = value.Rating,
                ReviewDate = value.ReviewDate,
            }).ToList();
        }
    }
}
