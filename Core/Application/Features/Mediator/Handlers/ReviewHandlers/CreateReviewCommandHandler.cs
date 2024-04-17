using Application.Features.Mediator.Commands.ReviewCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CarID = request.CarID,
                Comment = request.Comment,
                CustomerImage = request.CustomerImage,
                CustomerName = request.CustomerName,
                Rating = request.Rating,
                ReviewDate = DateTime.UtcNow,
            });
        }
    }
}
