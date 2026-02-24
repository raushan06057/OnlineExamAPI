namespace OnlineExamApp.Services.UserMgmt.Application.Middleware.Extension;

public static class AuthenticationMiddlewareExtension
{
    public static void UseAuthenticationHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<AuthenticationMiddleware>();
    }
}