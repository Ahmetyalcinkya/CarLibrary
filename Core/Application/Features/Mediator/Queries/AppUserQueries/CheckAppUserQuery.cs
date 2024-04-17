using Application.Features.Mediator.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Queries.AppUserQueries
{
    public class CheckAppUserQuery : IRequest<CheckAppUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
