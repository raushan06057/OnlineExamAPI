namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteOrganizationCommand : IRequest<ResponseModel>
{
    public long Id { get; set; } 
}