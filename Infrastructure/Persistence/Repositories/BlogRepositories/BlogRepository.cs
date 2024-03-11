using Application.Interfaces.BlogInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;
        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

		public List<Blog> GetLastThreeBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(_b => _b.Author).OrderByDescending(_b => _b.BlogID).Take(3).ToList();
            return values;
        }
		public List<Blog> GetAllBlogsWithAuthor()
		{
			var values = _context.Blogs.Include(_b => _b.Author).ToList();
            return values;
		}
    }
}
