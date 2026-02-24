namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetOrgByIdQuery : IRequest<ResponseModel>
{
    public long Id { get; set; }
    public GetOrgByIdQuery(long id)
    {
        Id = id;
    }
}
