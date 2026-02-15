# GitHub API Client

A learning project for building a REST API client using ASP.NET Core Web API (.NET 8).

## What This Project Does

This API acts as a wrapper around the GitHub REST API. It demonstrates how to:
- Make HTTP requests to external APIs using HttpClient
- Handle different error scenarios professionally
- Structure a clean API client with proper separation of concerns

## Stage 1: Get Authenticated User Profile ✅

**Endpoint:** `GET /api/github/me`

Retrieves the authenticated GitHub user's profile by calling GitHub's `/user` endpoint.

**What was Built:**
- Controller endpoint that accepts HTTP GET requests
- Service layer that communicates with GitHub API using HttpClient
- Custom exception classes for 401 and 403 errors
- Comprehensive error handling for all scenarios
- Console logging for debugging

**Technologies Used:**
- ASP.NET Core Web API (.NET 8)
- HttpClient with factory pattern
- Options pattern for configuration (GitHub token)
- System.Text.Json for JSON parsing
- Swagger for API testing

**Error Handling:**
- 401 - Invalid GitHub token
- 403 - Token lacks permissions
- 502 - Bad response from GitHub
- 503 - Cannot reach GitHub
- 500 - Unexpected errors

## Setup

1. Get a GitHub Personal Access Token from https://github.com/settings/tokens

2. Add your token to `appsettings.Development.json`:
```json
{
  "GitHubSettings": {
    "Token": "your_token_here"
  }
}
```

3. Run the application:
```bash
dotnet run
```

4. Test at: https://localhost:7099/swagger

## What I Learned

- HttpClient factory pattern for managing HTTP connections
- Options pattern for strongly-typed configuration
- Creating custom exceptions for specific error scenarios
- Exception handling strategy: Service throws, Controller catches
- Mapping external API errors to appropriate HTTP status codes
- The difference between network errors and API errors
- Console logging for development debugging