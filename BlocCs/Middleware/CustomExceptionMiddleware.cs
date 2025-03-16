using System.Text.Json;

namespace BlocCs.Middleware;

/// <summary>
/// Customer exception middleware
/// </summary>
public class CustomExceptionMiddleware
{
    /// <summary>
    /// The request delegate
    /// </summary>   
    private readonly RequestDelegate _next;
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<CustomExceptionMiddleware> _logger;
    /// <summary>
    /// If the server is in development
    /// </summary>
    private readonly bool _isDevelopment;

    /// <summary>
    /// Custom exception middleware constructor
    /// </summary>
    /// <param name="next">An instance of <see cref="RequestDelegate"/></param>
    /// <param name="logger">An instance of <see cref="ILogger"/></param>
    /// <param name="env">An instance of <see cref="IWebHostEnvironment"/></param>
    public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _isDevelopment = env.IsDevelopment();
    }

    /// <summary>
    /// Invoke the request
    /// </summary>
    /// <param name="context">An instance of <see cref="HttpContext"/></param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the unhandled exception
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// The function to handle the exception
    /// </summary>
    /// <param name="context">An instance of <see cref="HttpContext"/></param>
    /// <param name="exception">An instance of <see cref="Exception"/></param>
    /// <returns></returns>
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, message) = exception switch
        {
            ArgumentException => (StatusCodes.Status400BadRequest, "Invalid argument provided."),

            KeyNotFoundException => (StatusCodes.Status404NotFound, "The requested resource was not found."),

            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized access."),

            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var developerDetails = _isDevelopment ? exception.ToString() : null;

        Console.WriteLine("In middleware exception");
        var errorResponse = new
        {
            status = statusCode,
            message = exception.Message,
            details = developerDetails
        };

        // Return the JSON response
        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}