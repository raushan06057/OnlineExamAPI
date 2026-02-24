namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetQuestionListByExamIdQuery:IRequest<ResponseModel>
{
    public long ExamId { get; set; }

    public GetQuestionListByExamIdQuery(long examId)
    {
        ExamId = examId;
    }
}
