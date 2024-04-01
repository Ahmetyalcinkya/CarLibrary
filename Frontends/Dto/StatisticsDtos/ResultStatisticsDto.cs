using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public decimal AverageHourlyPrice { get; set; }
        public decimal AverageDailyPrice { get; set; }
        public decimal AverageWeeklyPrice { get; set; }
        public decimal AverageMonthlyPrice { get; set; }
        public int AutoTransmissionCarsCount { get; set; }
        public int CarCountByMilesAgeLessThenOneThousand { get; set; }
        public int CarCountByFuelGasolineOrDiesel { get; set; }
        public int CarCountByE_Car { get; set; }
    }
}
