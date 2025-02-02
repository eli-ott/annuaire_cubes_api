using System.Data;

namespace BlocCs.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyName = "ApiKey";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var isSwagger = context.Request.Path.ToString().Contains("swagger");

        if (!isSwagger)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                throw new InvalidExpressionException("API key was not found");
            }

            var apiKey = Environment.GetEnvironmentVariable("API_KEY") ??
                         throw new InvalidExpressionException("Can't find API key");

            if (!apiKey.Equals(extractedApiKey))
            {
                throw new UnauthorizedAccessException("API key mismatch.");
            }
        }

        await _next(context);
    }
}