namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetExamAttemptByIdQuery : IRequest<ResponseModel>
{
    public long Id { get; set; }
    public GetExamAttemptByIdQuery(long id)
    {
        this.Id = id;
    }
}