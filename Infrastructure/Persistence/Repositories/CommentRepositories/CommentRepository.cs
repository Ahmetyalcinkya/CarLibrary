using Application.Features.RepositoryPattern;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;
        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Remove(Comment comment)
        {
            var value = _context.Comments.Find(comment.CommentID);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
    }
}
