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
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewID);
            value.Comment = request.Comment;
            value.CustomerName = request.CustomerName;
            value.CarID = request.CarID;
            value.CustomerImage = request.CustomerImage;
            value.ReviewDate = DateTime.UtcNow;
            value.Rating = request.Rating;
            await _repository.UpdateAsync(value);
        }
    }
}
