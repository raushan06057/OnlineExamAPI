namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetApplicationRoleByOrganizationIdQuery:IRequest<ResponseModel>
{
    public GetApplicationRoleByOrganizationIdQuery(long organizationId)
    {
        OrganizationId = organizationId;
    }
    public long OrganizationId {  get; set; }
}
