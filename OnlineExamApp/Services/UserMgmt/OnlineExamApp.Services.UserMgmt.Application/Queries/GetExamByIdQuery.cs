namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetExamByIdQuery : IRequest<ResponseModel>
{
    public int ExamId { get; set; }

    public GetExamByIdQuery(int examById)
    {
        ExamId = examById;
    }
}
