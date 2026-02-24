namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetAnswerByIdQuery : IRequest<ResponseModel>
{
    public GetAnswerByIdQuery(long id)
    {
        Id = id;
    }
    public long Id { get; set; }
}