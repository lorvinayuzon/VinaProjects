using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HandsOnExamApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException _:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case Exception _:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }
            return context.Response.WriteAsync(result);
        }
    }
}
