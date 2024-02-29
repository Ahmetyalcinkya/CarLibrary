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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BrandID = command.BrandID,
                CarCoverImageUrl = command.CarCoverImageUrl,
                Luggage = command.Luggage,
                MileAge = command.MileAge,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission,
                Fuel = command.Fuel,
                ListCoverImageUrl = command.ListCoverImageUrl,
            });
        }
    }
}
