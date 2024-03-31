using Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarBrandAndModelByRentPriceDailyMinQuery : IRequest<GetCarBrandAndModelByRentPriceDailyMinQueryResult>
    {
    }
}
