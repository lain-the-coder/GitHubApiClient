using System;
using System.Net.Http;
using GitHubApiClient.DTOs;


namespace GitHubApiClient.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;
        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
        }
        public async Task<GitHubUserDTO?> GetAuthenticatedUserAsync()
        {
            throw new NotImplementedException();
        }

    }
}
