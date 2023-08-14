using LibraryAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryAPI.Middlewares
{

    public class ErrorHandingMiddleware:IMiddleware
        {
            private readonly ILogger<ErrorHandingMiddleware> _logger;

            public ErrorHandingMiddleware(ILogger<ErrorHandingMiddleware> logger)
            {
                this._logger = logger;
            }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 404;
                ProblemDetails problem = new()
                {
                    Status = 404,
                    Title = "Element not found",
                    Type = e.GetType().ToString(),
                    Detail = e.Message,
                };
                var json = JsonSerializer.Serialize(problem);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
            catch (BadRequestException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 400;
                ProblemDetails problem = new()
                {
                    Status = 400,
                    Title = "Bad Request",
                    Type = e.GetType().ToString(),
                    Detail = e.Message,
                };
                var json = JsonSerializer.Serialize(problem);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                ProblemDetails problem = new()
                {
                    Status = 500,
                    Title = "Server error",
                    Type = "Server error",
                    Detail = "An internal server has occurred",
                };
                var json = JsonSerializer.Serialize(problem);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}

