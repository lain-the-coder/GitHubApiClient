using GitHubApiClient.Services;
using GitHubApiClient.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<GitHubService>();
builder.Services.Configure<GitHubSettings>(builder.Configuration.GetSection("GitHub"));

var app = builder.Build();

app.Run();