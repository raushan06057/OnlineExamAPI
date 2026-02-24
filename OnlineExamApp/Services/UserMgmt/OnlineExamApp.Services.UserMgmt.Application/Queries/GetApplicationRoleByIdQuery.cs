namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetApplicationRoleByIdQuery:IRequest<ResponseModel>
{
    public GetApplicationRoleByIdQuery(string id)
    {
        Id = id;
    }
    public string Id {  get; set; }
}
