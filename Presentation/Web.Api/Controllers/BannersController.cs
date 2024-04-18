using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createCommandHandler;
        private readonly UpdateBannerCommandHandler _updateCommandHandler;
        private readonly RemoveBannerCommandHandler _removeCommandHandler;
        public BannersController(CreateBannerCommandHandler createCommandHandler, UpdateBannerCommandHandler updateCommandHandler, RemoveBannerCommandHandler removeCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _updateCommandHandler = updateCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetBannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("Banner added!");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateCommandHandler.Handle(command);
            return Ok("Banner updated!");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner deleted!");

        }
    }
}
