using Application.Enums;
using Application.Features.Mediator.Commands.AppUserCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                Username = request.Username,
                AppRoleID = (int) Roles.Member,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
            });
        }
    }
}
