namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteExamAttemptCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
}