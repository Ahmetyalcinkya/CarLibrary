using Application.Interfaces.ReviewInterfaces;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;
        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Review> GetCarReviewsByCarId(int carId)
        {
            var values = _context.Reviews.Where(review => review.CarID == carId).ToList();
            return values;
        }
    }
}
