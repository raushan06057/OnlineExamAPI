namespace OnlineExamApp.Services.UserMgmt.Application.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration configuration;

    // Dependency Injection
    public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        this.configuration = configuration;
    }

    public async Task Invoke(HttpContext context)
    {
        //Reading the AuthHeader which is signed with JWT
        string authHeader = context.Request.Headers[CommonFields.Authorization];
        if (authHeader != null)
        {
            var token = context.Request.Headers[CommonFields.Authorization].FirstOrDefault()?.Split(" ").Last();
            if (token != null && token!=CommonFields.Header)
            {
                attachAccountToContext(context, token);
            }
        }

        //Pass to the next middleware
        await _next(context);
    }

    private void attachAccountToContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration[CommonFields.JwtColonKey]??"N/A");
            var issuer = configuration[CommonFields.JwtColonIssuer];
            var audience = configuration[CommonFields.JwtColonAudience];

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = issuer,
                ValidAudience = audience
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var accountId = jwtToken.Claims.First(x => x.Type == CommonFields.ID).Value;
            var role = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role);
            // attach account to context on successful jwt validation
            context.Items[CommonFields.UserId] = accountId;
            //context.Items["User"] = _userService.GetUserDetails();
        }
        catch (Exception ex)
        {
            // do nothing if jwt validation fails
            // account is not attached to context so request won't have access to secure routes
        }
    }
}
