using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        private int id;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public GetBannerQueryHandler(int id)
        {
            this.id = id;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(value => new GetBannerQueryResult
            {
                BannerID = value.BannerID,
                Description = value.Description,
                Title = value.Title,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl,
            }).ToList();
        }
    }
}
