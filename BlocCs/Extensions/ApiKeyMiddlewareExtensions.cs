using BlocCs.Middleware;

namespace BlocCs.Extensions;

/// <summary>
/// Provices an api for the api key middleware
/// </summary>
public static class ApiKeyMiddlewareExtensions
{
    /// <summary>
    /// The api key middleware extension
    /// </summary>
    /// <param name="builder">An instance of <see cref="IApplicationBuilder"/></param>
    /// <returns>An instance of <see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiKeyMiddleware>();
    }
}