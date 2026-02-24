namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class UpdateOrgDepartmentCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Foreign key to OrganizationEntity
    public long OrganizationId { get; set; }
}
