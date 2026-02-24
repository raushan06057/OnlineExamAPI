namespace OnlineExamApp.Services.UserMgmt.Application.Queries;

public class GetAnswerOptionListQuery : IRequest<ResponseModel>
{
    public long QuestionId { get; set; } = 0;
    public GetAnswerOptionListQuery(long questionId)
    {
        this.QuestionId = questionId;
    }
}
