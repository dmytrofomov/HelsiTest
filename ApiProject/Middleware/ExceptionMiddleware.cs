using HelsiTest.Common.Exceptions;
using Microsoft.Extensions.Logging;

namespace HelsiTest.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment webHostEnvironment)
    {
        try
        {
            await _next(httpContext);
        }
        
        catch (ObjectNotFoundException ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

            logger.LogError(ex, "Object not found");

            if (!webHostEnvironment.IsProduction())
            {
                await httpContext.Response.WriteAsync(ex.ToString());
            }
        }
        catch (PermissionDeniedException ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

            logger.LogError(ex, "User with can't do this actions");

            if (!webHostEnvironment.IsProduction())
            {
                await httpContext.Response.WriteAsync(ex.ToString());
            }
        }
        catch (Exception ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            logger.LogError(ex, "Unhandled exception");

            if (!webHostEnvironment.IsProduction())
            {
                await httpContext.Response.WriteAsync(ex.ToString());
            }
        }
    }
}