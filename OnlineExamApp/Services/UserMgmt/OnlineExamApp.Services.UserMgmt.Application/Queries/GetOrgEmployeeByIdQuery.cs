namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgEmployeeByIdQuery : IRequest<ResponseModel>
{
    public long EmpId { get; set; }
    public GetOrgEmployeeByIdQuery(long empId)
    {
        EmpId = empId;
    }
}
