using BlocCs.Middleware;

namespace BlocCs.Extensions;

/// <summary>
/// Provides custom exception
/// </summary>
public static class CustomExceptionMiddlewareExtensions
{
    /// <summary>
    /// The custom exception extension
    /// </summary>
    /// <param name="builder">An instance of <see cref="IApplicationBuilder"/></param>
    /// <returns>An instance of <see cref="IApplicationBuilder"/></returns>
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionMiddleware>();
    }
}