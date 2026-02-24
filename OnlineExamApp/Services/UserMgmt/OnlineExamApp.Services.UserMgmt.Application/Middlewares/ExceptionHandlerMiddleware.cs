using Newtonsoft.Json;

namespace OnlineExamApp.Services.UserMgmt.Application.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate requestDelegate;
    public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.requestDelegate = requestDelegate;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await requestDelegate.Invoke(context);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Request finished: {context.Request.Method} {context.Request.Path}, Status: {context.Response.StatusCode}");
            await HandleExceptionMessgeAsync(context, ex).ConfigureAwait(false);
        }
    }

    public static Task HandleExceptionMessgeAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        int statusCode = (int)HttpStatusCode.InternalServerError;
        var result = JsonConvert.SerializeObject(new
        {
            Success = false,
            Message = exception.Message,
            data = exception,
            StatusCode = statusCode,
        });
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(result);
    }
}