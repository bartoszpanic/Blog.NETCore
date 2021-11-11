using Blog.NETCore.Application.Middleware.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundEx)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundEx.Message);
            }
            catch (BadRequestException badRequestEx)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestEx.Message);
            }
        }
    }
}
