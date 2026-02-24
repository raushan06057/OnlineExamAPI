namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgDepartmentByOrganizationIdQuery : IRequest<ResponseModel>
{
    public long OrganizationId { get; set; }
    public GetOrgDepartmentByOrganizationIdQuery(long organizationId)
    {
        OrganizationId = organizationId;
    }
}