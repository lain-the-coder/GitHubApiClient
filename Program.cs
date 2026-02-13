using GitHubApiClient.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<GitHubService>();

var app = builder.Build();

app.Run();