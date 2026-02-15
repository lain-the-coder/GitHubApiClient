using GitHubApiClient.DTOs;

namespace GitHubApiClient.Services
{
    public interface IGitHubService
    {
        Task<GitHubUserDTO> GetAuthenticatedUserAsync();
    }
}
