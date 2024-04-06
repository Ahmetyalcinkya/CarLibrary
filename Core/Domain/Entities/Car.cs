using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string ListCoverImageUrl { get; set; }
        public int MileAge { get; set; }
        public string Transmission {  get; set; }
        public byte Seat {  get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string CarCoverImageUrl { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> Processes { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
