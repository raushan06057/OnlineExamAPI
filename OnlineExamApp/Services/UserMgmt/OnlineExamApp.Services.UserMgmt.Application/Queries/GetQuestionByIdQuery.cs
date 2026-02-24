namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetQuestionByIdQuery : IRequest<ResponseModel>
{
    public int Id { get; set; }

    public GetQuestionByIdQuery(int id)
    {
        Id = id;
    }
}
