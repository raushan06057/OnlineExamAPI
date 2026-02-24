namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteOrgDepartmentCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
}