namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateApplicationRoleCommand : IRequest<ResponseModel>
{
    public long OrganizationId { get; set; }
    public string Name { get; set; } = string.Empty;
}