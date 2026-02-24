namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetUserListQuery:IRequest<ResponseModel>
{
    public long OrganizationId { get; set; }
    public GetUserListQuery(long organizationId)
    {
        OrganizationId = organizationId;
    }
}
