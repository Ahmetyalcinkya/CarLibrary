using Application.Interfaces.CarFeatureInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;
        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }


        public List<CarFeature> GetCarFeatureByCarID(int id)
        {
            var values = _context.CarFeatures.Include(car => car.Features).Where(carFeature => carFeature.CarID == id).ToList();
            return values;
        }
        public void ChangeCarFeatureAvailableStatusToFalse(int id)
        {
            var value = _context.CarFeatures.Where(carFeature => carFeature.CarFeatureID == id).FirstOrDefault();
            value.isAvailable = false;
            _context.SaveChangesAsync();
        }

        public void ChangeCarFeatureAvailableStatusToTrue(int id)
        {
            var value = _context.CarFeatures.Where(carFeature => carFeature.CarFeatureID == id).FirstOrDefault();
            value.isAvailable = true;
            _context.SaveChangesAsync();
        }
    }
}
