using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace Shared.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate _request;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _request = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception exception)
            {
                context.Response.ContentType = JsonContentType;

                void SetErrorMessage(string message)
                {
                    context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new GlobalErrorDetails
                        {
                            Message = message
                        }));

                    _logger.LogError($"Message: {message}. Endpoint: {context.Request.Path}. StatusCode: {context.Response.StatusCode}");
                }

                switch (exception)
                {
                    case var _ when exception is ValidationException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        SetErrorMessage(exception.Message);
                        break;
                    case var _ when exception is UnauthorizedAccessException:
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        SetErrorMessage("You have no access");
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        SetErrorMessage("Internal server error");
                        break;
                }                
            }
        }
    }
}

