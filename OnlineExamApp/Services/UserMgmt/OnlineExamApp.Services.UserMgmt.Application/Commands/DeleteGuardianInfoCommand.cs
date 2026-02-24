namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteGuardianInfoCommand:IRequest<ResponseModel>
{
    public long Id { get; set; }
}
