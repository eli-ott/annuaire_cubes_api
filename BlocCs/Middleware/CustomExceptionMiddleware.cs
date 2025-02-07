using System.Text.Json;

namespace BlocCs.Middleware;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionMiddleware> _logger;
    private readonly bool _isDevelopment;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _isDevelopment = env.IsDevelopment();
    }

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