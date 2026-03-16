using Institution.Infrastructure.Exceptions;
using System.Net;
using System.Text.Json;

namespace Institution.API.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        context.Response.StatusCode = exception switch
        {
            NotFoundException => (int)HttpStatusCode.NotFound,
            ConflictException => (int)HttpStatusCode.Conflict,
            AppException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError           
        };

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message,
            Detail = exception.StackTrace?.ToString()
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}