namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class LoginCommand(string username, string password) : IRequest<ResponseModel>
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}
