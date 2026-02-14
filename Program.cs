using GitHubApiClient.Services;
using GitHubApiClient.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<GitHubService>();
builder.Services.Configure<GitHubSettings>(builder.Configuration.GetSection("GitHub"));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();