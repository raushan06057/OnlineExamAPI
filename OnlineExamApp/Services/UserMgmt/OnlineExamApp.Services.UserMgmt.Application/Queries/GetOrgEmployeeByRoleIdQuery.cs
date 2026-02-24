namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgEmployeeByRoleIdQuery : IRequest<ResponseModel>
{
    public string RoleId { get; set; }
    public GetOrgEmployeeByRoleIdQuery(string roleId)
    {
        RoleId = roleId;
    }
}