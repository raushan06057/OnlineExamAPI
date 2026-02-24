namespace OnlineExamApp.Services.UserMgmt.Application.Middleware;

public class JWTMiddleware
{
    private readonly RequestDelegate requestDelegate;
    private readonly IConfiguration configuration;
    public JWTMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
    {
        this.requestDelegate = requestDelegate;
        this.configuration = configuration;
    }
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers[CommonFields.Authorization].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
            //Validate the token
            attachUserToContext(context, token);
        await requestDelegate(context);
    }
    private void attachUserToContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[CommonFields.JwtColonKey]));
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = key,
                ValidIssuer = configuration[CommonFields.JwtColonIssuer],
                ValidAudience = configuration[CommonFields.JwtColonKey],
                // set clockskew to zero so tokens expire exactly at token expiration time.
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == CommonFields.UserId).Value);
            var role=jwtToken.Claims.First(x=>x.Type==ClaimTypes.Role);
            // attach user to context on successful jwt validation
            context.Items[CommonFields.UserId] = userId;
        }
        catch (Exception)
        {
            // do nothing if jwt validation fails
            // user is not attached to context so request won't have access to secure routes
        }
    }
}