using System;
using System.Net.Http;
using GitHubApiClient.DTOs;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using GitHubApiClient.Configuration;
using System.Net;
using GitHubApiClient.Exceptions;


namespace GitHubApiClient.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;
        private readonly GitHubSettings _settings;
        public GitHubService(HttpClient httpClient, IOptions<GitHubSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
            _settings = settings.Value;
        }
        public async Task<GitHubUserDTO> GetAuthenticatedUserAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "user");
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue("MyAppName", "1.0"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",_settings.Token);
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException("You are not authorized to make this request.");
            }
            var result = await response.Content.ReadFromJsonAsync<GitHubUserDTO>();
            return result!;
        }
    }
}
