using System.Text.Json.Serialization;

namespace GitHubApiClient.DTOs
{
    public class GitHubUserDTO
    {
        [JsonPropertyName("login")]
        public required string Login { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("bio")]
        public string? Bio { get; set; }
        [JsonPropertyName("public_repos")]
        public int PublicRepos { get; set; }
        [JsonPropertyName("followers")]
        public int Followers { get; set; }
        [JsonPropertyName("following")]
        public int Following { get; set; }
    }
}
