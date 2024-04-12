using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeatureByCarID(int id);
        void ChangeCarFeatureAvailableStatusToFalse(int id);
        void ChangeCarFeatureAvailableStatusToTrue(int id);
    }
}
