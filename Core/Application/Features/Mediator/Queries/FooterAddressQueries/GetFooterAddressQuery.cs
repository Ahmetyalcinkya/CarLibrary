using Application.Features.Mediator.Results.FooterAddressResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {

    }
}
