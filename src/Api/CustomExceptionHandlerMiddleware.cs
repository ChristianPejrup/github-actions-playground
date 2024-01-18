using Api.Core;

namespace Api;

public class CustomExceptionHandlerMiddleware : IMiddleware
{
    private readonly IWebHostEnvironment _environment;

    public CustomExceptionHandlerMiddleware( IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = GetStatusCode(exception);


        await context.Response.WriteAsJsonAsync(GetErrorMessage(exception));
    }

    private int GetStatusCode(object exceptionType)
    {
        switch (exceptionType)
        {
            case BaseException _:
                return StatusCodes.Status400BadRequest;
            default:
                return StatusCodes.Status500InternalServerError;
        }
    }

    private ErrorMessage GetErrorMessage(Exception exception)
    {
        if (exception.GetType().IsSubclassOf(typeof(BaseException)) ||
            _environment.IsDevelopment())
        {
            return new ErrorMessage(exception.Message, exception.StackTrace!);
        }
        return new ErrorMessage("Internal server error");
    }

    private record ErrorMessage(string Message, string StackTrace = default);
}