using Application.Interfaces.CarInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;
        public CarRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<Car> GetCarListWithBrand()
        {
            var values = _context.Cars.Include(c => c.Brand).ToList();
            return values;
        }
    }
}
