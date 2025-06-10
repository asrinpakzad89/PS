using CMMSAPP.Application.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CMMSAPP.Application.Extentions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
