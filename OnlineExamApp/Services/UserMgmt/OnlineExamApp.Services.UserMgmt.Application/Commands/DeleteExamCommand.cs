namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteExamCommand : IRequest<ResponseModel>
{
    public int Id { get; set; }
}