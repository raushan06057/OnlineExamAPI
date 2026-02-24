namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateApplicationRoleCommand:IRequest<ResponseModel>
{
    public string Id { get; set; } = string.Empty;
    public long OrganizationId { get; set; }
    public string Name { get; set; } = string.Empty;
}
