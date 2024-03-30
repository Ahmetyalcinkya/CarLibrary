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

		public List<Car> GetLastFiveCarsWithBrand()
        {
            var values = _context.Cars.Include(_c => _c.Brand).OrderByDescending(_c => _c.CarID).Take(5).ToList();
            return values;
        }
        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }
    }
}
