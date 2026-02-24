namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgEmployeeListByDeptIdQuery : IRequest<ResponseModel>
{
    public long DeptId { get; set; }
    public GetOrgEmployeeListByDeptIdQuery(long deptId)
    {
        DeptId = deptId;
    }
}
