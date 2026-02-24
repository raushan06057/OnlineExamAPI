namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgEmployeeListByOrgIdQuery : IRequest<ResponseModel>
{
    public long OrganizationId { get; set; }
    public GetOrgEmployeeListByOrgIdQuery(long organizationId)
    {
        OrganizationId = organizationId;
    }
}