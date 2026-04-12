using ECommerce.Application.Common;
using FluentValidation;
using System.Text.Json;

namespace ECommerce.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, message) = exception switch
        {
            KeyNotFoundException => (404, exception.Message),
            ValidationException ex => (400, string.Join(", ", ex.Errors.Select(e => e.ErrorMessage))),
            UnauthorizedAccessException => (401, exception.Message),
            _ => (500, exception.Message)
        };

        var response = ApiResponse.Fail(message, statusCode);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
