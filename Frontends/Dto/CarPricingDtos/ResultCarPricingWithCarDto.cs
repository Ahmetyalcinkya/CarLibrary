﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.CarPricingDtos
{
	public class ResultCarPricingWithCarDto
	{
		public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public string Brand { get; set; }
		public string Model { get; set; }
		public decimal Amount { get; set; }
		public string ListCoverImageUrl { get; set; }
	}
}
