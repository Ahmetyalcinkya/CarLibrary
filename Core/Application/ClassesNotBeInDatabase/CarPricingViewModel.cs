using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassesNotBeInDatabase
{
	public class CarPricingViewModel
	{
		public CarPricingViewModel()
		{
			Amounts = new List<decimal>();
		}

		public string Model { get; set; }
        public List<Decimal> Amounts { get; set; }
        public string ListCoverImageUrl { get; set; }
		// public int BrandID { get; set; }
    }
}
