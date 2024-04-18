using Application.Features.Mediator.Commands.CommentCommands;
using Application.Features.RepositoryPattern;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;
        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Comment saved successfully!");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateCommentWithMediator")]
        public IActionResult CreateCommentWithMediator(CreateCommentCommand command)
        {
            _mediator.Send(command);
            return Ok("Comment saved successfully!");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Comment updated successfully!");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Comment removed successfully!");
        }
    }
}
