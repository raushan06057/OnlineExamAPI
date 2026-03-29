namespace OnlineExamApp.Services.UserMgmt.Core.IRepositories;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}