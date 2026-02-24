namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteAnswerOptionCommand:IRequest<ResponseModel>
{
    public long Id { get; set; }
}
