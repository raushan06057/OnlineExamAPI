namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteOrgEmployeeCommand:IRequest<ResponseModel>
{
    public long Id { get; set; }
}