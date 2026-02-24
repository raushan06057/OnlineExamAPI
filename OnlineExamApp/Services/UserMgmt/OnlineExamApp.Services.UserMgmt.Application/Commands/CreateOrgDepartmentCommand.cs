namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class CreateOrgDepartmentCommand : IRequest<ResponseModel>
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Foreign key to OrganizationEntity
    public long OrganizationId { get; set; }
}