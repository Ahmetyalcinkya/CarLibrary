using Application.Interfaces.CarPricingInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;
		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingsWithCars()
		{
			var values = _context.CarPricings.Include(_cp => _cp.Car).ThenInclude(_c => _c.Brand).Include(_b => _b.Pricing).ToList();
			return values;
		}
	}
}
