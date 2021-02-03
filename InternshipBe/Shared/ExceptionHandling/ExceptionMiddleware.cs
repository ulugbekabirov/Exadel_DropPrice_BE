using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Shared.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate _request;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _request = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _request(context);
            }
            catch (Exception exception)
            {
                var httpStatusCode = ConfigurateExceptionTypes(exception);

                context.Response.StatusCode = httpStatusCode;
                context.Response.ContentType = JsonContentType;
                if (httpStatusCode == 400)
                {
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new GlobalErrorDetails
                        {
                            Message = "Bad Request"
                        }));
                }
                if(httpStatusCode == 401)
                {
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new GlobalErrorDetails
                        {
                            Message = "You Are Not Welcome Here"
                        }));
                }
                else
                {
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new GlobalErrorDetails
                        {
                            Message = "internal server error"
                        }));
                }
            }
        }

        private static int ConfigurateExceptionTypes(Exception exception)
        {
            int httpStatusCode;

            switch (exception)
            {
                case var _ when exception is ValidationException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case var _ when exception is UnauthorizedAccessException:
                    httpStatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return httpStatusCode;
        }
    }

}

