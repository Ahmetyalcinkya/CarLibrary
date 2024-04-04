using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.RentACarDtos
{
	public class FilterRentACarDto
	{
        public int LocationID { get; set; }
        public bool isAvailable { get; set; }
    }
}
