using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarFeature
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int FeatureID { get; set; }
        public Feature Features { get; set; }
        public bool isAvailable { get; set; }
    }
}
