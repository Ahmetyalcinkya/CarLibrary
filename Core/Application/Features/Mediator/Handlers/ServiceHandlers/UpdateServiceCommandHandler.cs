using Application.Features.Mediator.Commands.ServiceCommands;
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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceID);
            value.Title = request.Title;
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
