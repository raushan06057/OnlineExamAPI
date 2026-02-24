namespace OnlineExamApp.Services.UserMgmt.Application.Commands;

public class DeleteCourseCommand : IRequest<ResponseModel>
{
    public long Id { get; set; }
}