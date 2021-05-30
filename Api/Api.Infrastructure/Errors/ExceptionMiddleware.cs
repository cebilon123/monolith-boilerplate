using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api.Infrastructure.Errors
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionToResponseMapper _exceptionToResponseMapper;

        public ExceptionMiddleware(RequestDelegate next, IExceptionToResponseMapper exceptionToResponseMapper)
        {
            _next = next;
            _exceptionToResponseMapper = exceptionToResponseMapper;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                await _next.Invoke(ctx);
            }
            catch (Exception e)
            {
                var response = ctx.Response;
                response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(_exceptionToResponseMapper.GetErrorBasedOnException(e));
                await response.WriteAsync(result);
            }
        }
    }
}