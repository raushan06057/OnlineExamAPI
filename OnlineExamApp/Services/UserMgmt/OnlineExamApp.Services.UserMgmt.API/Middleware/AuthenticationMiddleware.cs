namespace OnlineExamApp.Services.UserMgmt.API.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate next;
    private readonly IConfiguration configuration;
    public AuthenticationMiddleware(RequestDelegate next,IConfiguration configuration)
    {
        this.next = next;
        this.configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers[CommonFields.Authorization].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
        {
            AttachUserToContext(context, token);
        }
        await next(context);
    }
    private void AttachUserToContext(HttpContext context,string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration[CommonFields.JwtColonKey] ?? "N/A");
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = configuration[CommonFields.JwtColonIssuer],
            ValidAudience = configuration[CommonFields.JwtColonAudience]
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var accountId = jwtToken.Claims.First(x => x.Type == CommonFields.ID).Value;
        var role = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role);
        // attach account to context on successful jwt validation
        context.Items[CommonFields.UserId] = accountId;
        context.Items[CommonFields.RoleId]= role;
    }
}
