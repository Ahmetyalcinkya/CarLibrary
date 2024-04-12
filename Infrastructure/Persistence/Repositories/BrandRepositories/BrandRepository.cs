using Application.Interfaces.BrandInterfaes;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BrandRepositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly CarBookContext _context;
        public BrandRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBrandName(int id)
        {
            var value = _context.Brands.Where(brand => brand.BrandID == id).FirstOrDefault();
            return value.Name;
        }
    }
}
