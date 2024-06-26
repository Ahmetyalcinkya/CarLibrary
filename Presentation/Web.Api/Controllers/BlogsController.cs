﻿using Application.Features.Mediator.Commands.BlogCommands;
using Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("GetLastThreeBlogsWithAuthorsList")]
        public async Task<IActionResult> GetLastThreeBlogsWithAuthorsList()
        {
            var values = await _mediator.Send(new GetLastThreeBlogsWithAuthorsQuery());
            return Ok(values);
        } 
        [HttpGet("GetAllBlogsWithAuthor")]
        public async Task<IActionResult> GetAllBlogsWithAuthor()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        } 
        [HttpGet("GetBlogsAuthorById")]
        public async Task<IActionResult> GetBlogsAuthorById(int id)
        {
            var values = await _mediator.Send(new GetBlogsAuthorByIdQuery(id));
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog successfully saved!");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog successfully updated!");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog successfully deleted!");
        }
    }
}
