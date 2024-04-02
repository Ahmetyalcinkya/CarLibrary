using Application.Interfaces.StatisticsInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;
        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public int GetAutoTransmissionCarsCount()
        {
            var value = _context.Cars.Where(car => car.Transmission == "Automatic").Count();
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public string GetBlogTitleWithMostComments()
        {
            throw new NotImplementedException();
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //SELECT * FROM public."CarPricings" AS cp WHERE cp."Amount" = (SELECT MAX("Amount") FROM public."CarPricings" AS cp WHERE cp."PricingID" = 3);
            int pricingID = _context.Pricings.Where(pricing => pricing.Name == "Daily").Select(pricing => pricing.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(carPricing => carPricing.PricingID == pricingID).Max(carPricing => carPricing.Amount);
            int carID = _context.CarPricings.Where(carPricing => carPricing.Amount == amount).Select(carPricing => carPricing.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(car => car.CarID == carID).Include(brand => brand.Brand).Select(car => car.Brand.Name + " " + car.Model).FirstOrDefault();
            return brandModel;

        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            //SELECT * FROM public."CarPricings" AS cp WHERE cp."Amount" = (SELECT MIN("Amount") FROM public."CarPricings" AS cp WHERE cp."PricingID" = 3);
            int pricingID = _context.Pricings.Where(pricing => pricing.Name == "Daily").Select(pricing => pricing.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(carPricing => carPricing.PricingID == pricingID).Min(carPricing => carPricing.Amount);
            int carID = _context.CarPricings.Where(carPricing => carPricing.Amount == amount).Select(carPricing => carPricing.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(car => car.CarID == carID).Include(brand => brand.Brand).Select(car => car.Brand.Name + " " + car.Model).FirstOrDefault();
            return brandModel;
        }
        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByE_Car()
        {
            var value = _context.Cars.Where(car => car.Fuel == "Electric").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(car => car.Fuel == "Gasoline" || car.Fuel == "Diesel").Count();
            return value;
        }

        public int GetCarCountByMilesAgeLessThenOneThousand()
        {
            var value = _context.Cars.Where(car => car.MileAge < 1000).Count();
            return value;
        }

        public decimal GetCarsAverageDailyPrice()
        {
            //SELECT AVG("Amount") FROM public."CarPricings" AS cp WHERE cp."PricingID" = (SELECT "PricingID" FROM public."Pricings" AS pr WHERE pr."Name" = 'Daily')
            int id = _context.Pricings.Where(pricing => pricing.Name == "Daily").Select(pricing => pricing.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(carPricing => carPricing.PricingID == id).Average(carPricing => carPricing.Amount);
            return value;
        }

        public decimal GetCarsAverageHourlyPrice()
        {
            //SELECT AVG("Amount") FROM public."CarPricings" AS cp WHERE cp."PricingID" = (SELECT "PricingID" FROM public."Pricings" AS pr WHERE pr."Name" = 'Hourly')
            int id = _context.Pricings.Where(pricing => pricing.Name == "Hourly").Select(pricing => pricing.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(carPricing => carPricing.PricingID == id).Average(carPricing => carPricing.Amount);
            return value;
        }

        public decimal GetCarsAverageMonthlyPrice()
        {
            //SELECT AVG("Amount") FROM public."CarPricings" AS cp WHERE cp."PricingID" = (SELECT "PricingID" FROM public."Pricings" AS pr WHERE pr."Name" = 'Monthly')
            int id = _context.Pricings.Where(pricing => pricing.Name == "Monthly").Select(pricing => pricing.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(carPricing => carPricing.PricingID == id).Average(carPricing => carPricing.Amount);
            return value;
        }

        public decimal GetCarsAverageWeeklyPrice()
        {
            //SELECT AVG("Amount") FROM public."CarPricings" AS cp WHERE cp."PricingID" = (SELECT "PricingID" FROM public."Pricings" AS pr WHERE pr."Name" = 'Weekly')
            int id = _context.Pricings.Where(pricing => pricing.Name == "Weekly").Select(pricing => pricing.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(carPricing => carPricing.PricingID == id).Average(carPricing => carPricing.Amount);
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }

        public string GetMostPopularBrandName()
        {
            throw new NotImplementedException();
        }
    }
}
