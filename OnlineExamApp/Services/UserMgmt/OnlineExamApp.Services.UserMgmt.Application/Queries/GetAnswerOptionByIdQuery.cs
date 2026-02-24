namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetAnswerOptionByIdQuery : IRequest<ResponseModel>
{
    public GetAnswerOptionByIdQuery(long id)
    {
        Id = id;
    }
    public long Id { get; set; }
}