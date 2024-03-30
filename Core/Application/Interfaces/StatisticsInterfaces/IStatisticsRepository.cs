using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetCarsAverageHourlyPrice();
        decimal GetCarsAverageDailyPrice();
        decimal GetCarsAverageWeeklyPrice();
        decimal GetCarsAverageMonthlyPrice();
        int GetAutoTransmissionCarsCount();
        string GetMostPopularBrandName();
        string GetBlogTitleWithMostComments();
        int GetCarCountByMilesAgeLessThenOneThousand();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByE_Car();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
    }
}
