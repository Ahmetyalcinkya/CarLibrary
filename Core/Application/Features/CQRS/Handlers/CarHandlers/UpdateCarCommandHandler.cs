using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            value.Fuel = command.Fuel;
            value.Transmission = command.Transmission;
            value.BrandID = command.BrandID;
            value.CarCoverImageUrl = command.CarCoverImageUrl;
            value.MileAge = command.MileAge;
            value.ListCoverImageUrl = command.ListCoverImageUrl;
            value.Luggage = command.Luggage;
            value.Seat = command.Seat;
            value.Model = command.Model;
            await _repository.UpdateAsync(value);
        }
    }
}
