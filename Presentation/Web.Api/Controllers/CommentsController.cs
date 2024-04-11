using Application.Features.RepositoryPattern;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public IActionResult GetComments() 
        { 
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);
        }
        [HttpGet("GetCommentByBlogId")]
        public IActionResult GetCommentByBlogId(int id)
        {
            var value = _commentRepository.GetCommentByBlogId(id);
            return Ok(value);
        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id)
        {
            var value = _commentRepository.CommentCountByBlog(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Comment saved successfully!");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Comment updated successfully!");
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Comment removed successfully!");
        }
    }
}
