using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdQueryResult
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string ListCoverImageUrl { get; set; }
        public int MileAge { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string CarCoverImageUrl { get; set; }    
    }
}
