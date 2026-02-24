namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetCourseListByOrgIdQuery:IRequest<ResponseModel>
{
    public long OrgId { get; set; }
    public GetCourseListByOrgIdQuery(long orgId)
    {
        OrgId = orgId;
    }
}
