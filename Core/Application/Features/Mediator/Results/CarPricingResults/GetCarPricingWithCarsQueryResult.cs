using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingWithCarsQueryResult
	{
		public int CarPricingID { get; set; }
		public string Brand {  get; set; }
		public string Model {  get; set; }
		public decimal Amount {  get; set; }
		public string ListCoverImageUrl {  get; set; }
	}
}
