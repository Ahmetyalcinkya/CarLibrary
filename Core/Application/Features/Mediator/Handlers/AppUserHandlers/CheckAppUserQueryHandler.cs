using Application.Features.Mediator.Queries.AppUserQueries;
using Application.Features.Mediator.Results.AppUserResults;
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
    public class CheckAppUserQueryHandler : IRequestHandler<CheckAppUserQuery, CheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;
        public CheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<CheckAppUserQueryResult> Handle(CheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var value = new CheckAppUserQueryResult();
            var user =  await _appUserRepository.GetByFilterAsync(user => user.Username == request.Username && user.Password == request.Password);
            if (user == null)
            {
                value.isExist = false;
            }
            else
            {
                value.isExist = true;
                value.Username = user.Username;
                value.Role = (await _appRoleRepository.GetByFilterAsync(role => role.AppRoleID == user.AppRoleID)).AppRoleName;
                value.Id = user.AppUserID;
            }
            return value;
        }
    }
}
