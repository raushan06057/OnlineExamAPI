namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetExamListQuery : IRequest<ResponseModel>
{
    public string? Username { get; set; }
    public GetExamListQuery(string username)
    {
        this.Username = username;
    }
}