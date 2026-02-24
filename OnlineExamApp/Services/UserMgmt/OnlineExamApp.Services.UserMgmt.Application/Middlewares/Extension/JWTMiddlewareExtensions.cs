using Microsoft.AspNetCore.Builder;

namespace OnlineExamApp.Services.UserMgmt.Application.Middleware.Extension;

public static class JWTMiddlewareExtensions
{
    public static void UseJWTMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<JWTMiddleware>();
    }
}