using Microsoft.AspNetCore.Mvc;
using GitHubApiClient.Services;
using GitHubApiClient.DTOs;
using GitHubApiClient.Exceptions;
using System.Text.Json;

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
            catch (ForbiddenException ex)
            {
                return StatusCode(403, ex.Message);
            }
            catch (JsonException)
            {
                return StatusCode(502, "Received invalid response from GitHub.");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(502, ex.Message);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[ERROR] {DateTime.Now}: {ex.Message}");
                return StatusCode(503, "Unable to connect to GitHub. Please try again later.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {DateTime.Now}: {ex.GetType().Name} - {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}