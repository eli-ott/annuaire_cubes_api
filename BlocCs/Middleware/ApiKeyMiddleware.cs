using System.Data;

namespace BlocCs.Middleware;

/// <summary>
/// The middleware for the api key
/// </summary>
public class ApiKeyMiddleware
{
    /// <summary>
    /// The request delegate
    /// </summary>
    private readonly RequestDelegate _next;
    /// <summary>
    /// The api key name in the headers
    /// </summary>
    private const string ApiKeyName = "ApiKey";

    /// <summary>
    /// Api key middleware constructor
    /// </summary>
    /// <param name="next">An instance of <see cref="RequestDelegate"/></param>
    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invoke the request
    /// </summary>
    /// <param name="context">An instance of <see cref="HttpContext"/></param>
    /// <exception cref="InvalidExpressionException"></exception>
    /// <exception cref="UnauthorizedAccessException"></exception>
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