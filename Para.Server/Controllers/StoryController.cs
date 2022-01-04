using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Para.Server.Contracts;
using Para.Shared;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication;
using Para.Server.Services;
using Para.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Para.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepository<Stories> _storyRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUtilityService _utilityService;
        private readonly DataContext _context;

        public StoryController(IStoryRepository<Stories> storyRepo, IHttpContextAccessor httpContextAccessor, IUtilityService utilityService, DataContext context)
        {
            _storyRepo = storyRepo;
            _httpContextAccessor = httpContextAccessor;
            _utilityService = utilityService;
            _context = context;
        }

        [HttpGet("getuserstories/{name}")]
        public async Task<IActionResult> GetUserStory(string name)
        {
            //var user = await _utilityService.GetUser();
            
            var story = await _storyRepo.GetUsersStory(name);

            return Ok(story);
        }

        [HttpGet("getstories")]
        public async Task<IActionResult> GetAllStory()
        {
            //TODO Add enity framework and DB COntext, remove RavenDb unless I can find a way to authenicate user without using an int ID on the raven DB. A string ID makes it hard to call int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); since this wanta user wwith an ID of int. Raven DB I ahve not found a way yet.
            //var user = await _utilityService.GetUser();
            User user = await _context.Users.FirstOrDefaultAsync();
            var stories = await _context.UserStories.ToListAsync();
            
            return Ok(stories);
        }

        [HttpPost("newstory")]
        public async Task<IActionResult> CreateStory(Stories request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _storyRepo.InsertOrUpdate(request);
            return Ok(request);
        }

        
    }
}
