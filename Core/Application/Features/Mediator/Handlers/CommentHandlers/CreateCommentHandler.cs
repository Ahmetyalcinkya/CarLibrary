using Application.Features.Mediator.Commands.CommentCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.CommentHandlers
{
    internal class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;
        public CreateCommentHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                BlogID = request.BlogID,
                CreatedDate = DateTime.UtcNow,
                Description = request.Description,
                Name = request.Name,
            });
        }
    }
}
