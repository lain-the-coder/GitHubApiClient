using Microsoft.AspNetCore.Mvc;
using GitHubApiClient.Services;
using GitHubApiClient.DTOs;

namespace GitHubApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly GitHubService _githubService;
        public GitHubController(GitHubService githubService)
        {
            _githubService = githubService;
        }

        [HttpGet]
        [Route("me")]
        public async Task<ActionResult<GitHubUserDTO>> GetProfileAsync()
        {
            var profile = await _githubService.GetAuthenticatedUserAsync();
            if (profile == null)
            {
                return StatusCode(500, "Failed to retrieve GitHub profile.");
            }
            return Ok(profile);

        }

    }
}