using CMMSAPP.Common.Exceptions;
using CMMSAPP.Common.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CMMSAPP.Application.Middlewares;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, ILogger<CustomExceptionHandlerMiddleware> logger)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e) when (e is ValidationException ex)
        {
            logger.LogInformation(ex, "Validation exception occurred");
            await httpContext.Response.WriteValidationErrorsAsync(ex);
        }
        catch (Exception e) when (e is AppException ex)
        {
            logger.LogError(ex, "Application exception occurred");
            await httpContext.Response.WriteApplicationErrorsAsync(ex);
        }
        catch (Exception e) when (e is BusinessException ex)
        {
            logger.LogError(ex, "Business exception occurred");
            await httpContext.Response.WriteBusinessErrorsAsync(ex);
        }
        catch (Exception e) when (e is NotFoundException ex)
        {
            logger.LogError(ex, "Not found exception occurred");
            await httpContext.Response.WriteNotFoundErrorsAsync(ex);
        }
        catch (Exception e) when (e is DuplicateException ex)
        {
            await httpContext.Response.WriteDuplicateErrorsAsync(ex);
        }
        catch (Exception e) when (e is DatabaseException ex)
        {
            logger.LogError(ex, "Database exception occurred");
            await httpContext.Response.WriteDatabaseErrorsAsync(ex);
        }
        catch (Exception e) when (e is AuthenticationException ex)
        {
            logger.LogError(ex, "Authentication exception occurred");
            await httpContext.Response.WriteAuthenticationErrorsAsync(ex);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred.");
            await httpContext.Response.WriteUnhandledExceptionsAsync();
        }
    }
}
