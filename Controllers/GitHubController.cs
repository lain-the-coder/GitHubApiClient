using Microsoft.AspNetCore.Mvc;
using GitHubApiClient.Services;
using GitHubApiClient.DTOs;
using GitHubApiClient.Exceptions;

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
            try 
            {
                var profile = await _githubService.GetAuthenticatedUserAsync();
                return Ok(profile);
            }
            catch (UnauthorizedException ex)
            {
                return Unauthorized(ex.Message);
            }

        }

    }
}