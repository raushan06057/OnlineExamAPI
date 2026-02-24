namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteStudentInfoCommand : IRequest<ResponseModel>
{
    public int Id { get; set; }
}