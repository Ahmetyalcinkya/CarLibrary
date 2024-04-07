using Application.ClassesNotBeInDatabase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarPricingInterfaces
{
	public interface ICarPricingRepository
	{
		List<CarPricing> GetCarPricingsWithCars();
		List<CarPricingViewModel> GetCarPricingsWithTimePeriod();
	}
}
