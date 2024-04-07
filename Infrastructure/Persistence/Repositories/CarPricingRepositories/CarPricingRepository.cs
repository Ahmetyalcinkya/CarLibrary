using Application.ClassesNotBeInDatabase;
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
			var values = _context.CarPricings.Include(_cp => _cp.Car).ThenInclude(_c => _c.Brand).Include(_b => _b.Pricing).Where(_c => _c.PricingID == 2).ToList();
			return values;
		}

		public List<CarPricingViewModel> GetCarPricingsWithTimePeriod()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "SELECT * FROM crosstab('SELECT car.\"Model\", cp.\"PricingID\", cp.\"Amount\" FROM public.\"CarPricings\" as cp INNER JOIN public.\"Cars\" as car ON car.\"CarID\" = cp.\"CarID\" ORDER BY 1,2','SELECT DISTINCT \"PricingID\" FROM public.\"CarPricings\" ORDER BY 1') AS PivotTable (\"Model\" char varying,\"2\" numeric, \"3\" numeric, \"4\" numeric, \"7\" numeric);";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using(var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel();
						Enumerable.Range(1, 3).ToList().ForEach(pricing =>
						{
							carPricingViewModel.Model = reader[0].ToString();
							if (DBNull.Value.Equals(reader[pricing]))
							{
								carPricingViewModel.Amounts.Add(0);
							}
							else
							{
								carPricingViewModel.Amounts.Add(reader.GetDecimal(pricing));
							}
						});
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}
