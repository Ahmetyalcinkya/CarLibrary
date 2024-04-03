using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public List<RentACar> RentACars { get; set; }
    }
}
