namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgUserListByOrgIdQuery : IRequest<ResponseModel>
{
    public long OrganizationId { get; set; }
    public GetOrgUserListByOrgIdQuery(long organizationId)
    {
        OrganizationId = organizationId;
    }
}
