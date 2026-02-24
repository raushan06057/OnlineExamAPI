namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteQuestionCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
}
