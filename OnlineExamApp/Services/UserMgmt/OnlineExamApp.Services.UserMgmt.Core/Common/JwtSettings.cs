namespace OnlineExamApp.Services.UserMgmt.Core.Common;

public class JwtSettings(string secretKey,string expiresIn)
{
    public string SecretKey { get; set; } = secretKey;
    public string ExpiresIn { get; set; } = expiresIn;
}
