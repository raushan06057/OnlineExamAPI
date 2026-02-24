namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgDepartmentByIdQuery:IRequest<ResponseModel>
{
    public long Id { get; set; }
    public GetOrgDepartmentByIdQuery(long id)
    {
        Id = id;
    }
}
