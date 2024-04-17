using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        CarDescription GetCarDescription(int carId);
    }
}
