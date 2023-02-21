using CoolLibrary.BLL;
using CoolLibrary.BLL.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace CoolLibrary.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                switch (exception)
                {
                    case NotFoundException ex:
                        await HandleNotFoundException(httpContext, ex);
                        break;

                    case InvalidAttributeException ex:
                        await HandleInvalidAttributeException(httpContext, ex);
                        break;

                    case UnauthorizedException ex:
                        await HandleUnauthorizedException(httpContext, ex);
                        break;

                    default:
                        await HandleGenericException(httpContext, exception);
                        break;
                }
            }
            finally
            {
                HandleRequest(httpContext);
            }
        }

        private void HandleRequest(HttpContext httpContext)
        {
            _logger.LogInformation($"Method: {httpContext.Request.Method} " +
                                   $"Path: {httpContext.Request.Path} " +
                                   $"StatusCode: {httpContext.Response.StatusCode} ");
        }

        private async Task HandleNotFoundException(HttpContext httpContext, NotFoundException ex)
        {
            _logger.LogError(ex.Message);
            if (ex.InnerException != null)
                _logger.LogError(ex.InnerException.Message);
            await CreateExceptionAsync(httpContext, HttpStatusCode.NotFound, ex.Message);
        }

        private async Task HandleInvalidAttributeException(HttpContext httpContext, InvalidAttributeException ex)
        {
            _logger.LogError(ex.Message);
            if (ex.InnerException != null)
                _logger.LogError(ex.InnerException.Message);
            await CreateExceptionAsync(httpContext, HttpStatusCode.BadRequest, ex.Message);
        }

        private async Task HandleUnauthorizedException(HttpContext httpContext, UnauthorizedException ex)
        {
            _logger.LogError(ex.Message);
            if (ex.InnerException != null)
                _logger.LogError(ex.InnerException.Message);
            await CreateExceptionAsync(httpContext, HttpStatusCode.Forbidden, ex.Message);
        }

        private async Task HandleGenericException(HttpContext context, Exception ex)
        {
            _logger.LogError("{ex.Message}", ex.Message);
            if (ex.InnerException != null)
                _logger.LogError(ex.InnerException.Message);
            await CreateExceptionAsync(context);
        }

        private async Task CreateExceptionAsync(HttpContext context,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            object? errorBody = null)
        {
            errorBody ??= new { error = "Unknown error has occured" };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorBody));
        }
    }
}