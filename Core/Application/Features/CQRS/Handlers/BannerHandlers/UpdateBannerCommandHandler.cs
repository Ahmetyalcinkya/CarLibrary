using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerID);
            value.Title = command.Title;
            value.Description = command.Description;
            value.VideoDescription = command.VideoDescription;
            value.VideoUrl = command.VideoUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
