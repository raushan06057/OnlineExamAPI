namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgUserDetailsByIdQuery : IRequest<ResponseModel>
{
    public string? id { get; set; }
    public GetOrgUserDetailsByIdQuery(string id)
    {
        this.id = id;
    }
}
